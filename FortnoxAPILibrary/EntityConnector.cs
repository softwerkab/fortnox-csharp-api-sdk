using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public abstract class EntityConnector<TEntity, TEntityCollection, TSort> : BaseConnector where TEntity : class
    {
        protected Dictionary<string, string> ParametersInjection { get; set; } //TODO: Remove, temporary workaround

        protected async Task<TEntity> BaseCreate(TEntity entity)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Post,
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            var result = await DoEntityRequest(wrappedEntity).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task<TEntity> BaseUpdate(TEntity entity, params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Put,
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };

            var result = await DoEntityRequest(wrappedEntity).ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task BaseDelete(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Delete
            };
            ParametersInjection = null;

            await DoRequest().ConfigureAwait(false);
        }

        protected async Task<TEntity> BaseGet(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityWrapper<TEntity>>().ConfigureAwait(false);
            return result?.Entity;
        }

        protected async Task<TEntityCollection> BaseFind(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                SearchParameters = GetSearchParameters(),
                Method = HttpMethod.Get,
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<TEntityCollection>().ConfigureAwait(false);
            return result;
        }

        protected Dictionary<string, string> GetSearchParameters()
        {
            var searchObjProperty = GetType().GetProperty("Search");
            var searchObj = searchObjProperty.GetValue(this);
            var searchProperties = GetSearchParameters(searchObj).ToList();
            var other = GetSearchParameters(this).ToList();

            return searchProperties.Concat(other).ToDictionary(x => x.Key, x => x.Value);
        }

        protected static Dictionary<string, string> GetSearchParameters(object obj)
        {
            var searchParams = new Dictionary<string, string>();

            foreach (var property in obj.GetType().GetProperties())
            {
                var isSearchParameter = property.HasAttribute<SearchParameter>();
                if (!isSearchParameter) continue;

                var value = property.GetValue(obj);
                var strValue = GetStringValue(value, property.PropertyType);
                if (string.IsNullOrWhiteSpace(strValue)) continue;

                var searchAttribute = property.GetAttribute<SearchParameter>();
                var paramName = searchAttribute.Name ?? property.Name;

                searchParams.Add(paramName.ToLower(), strValue);
            }

            return searchParams;
        }

        private static string GetStringValue(object value, Type type)
        {
            if (value == null) return null;

            type = Nullable.GetUnderlyingType(type) ?? type; //unwrap nullable type

            if (type == typeof(string))
                return value.ToString();
            if (type.IsEnum)
               return ((Enum)value).GetStringValue();
            if (type == typeof(DateTime))
            {
                if (((DateTime)value).Date == (DateTime)value) //Date without hours/minutes/seconds..
                    return ((DateTime)value).ToString(APIConstants.DateFormat);

                return ((DateTime) value).ToString(APIConstants.DateAndTimeFormat);
            }

            return value.ToString().ToLower();
        }

        protected TEntity DoAction(string documentNumber, Action action)
        {
            return DoActionAsync(documentNumber, action).Result;
        }

        protected byte[] DoDownloadAction(string documentNumber, Action action, string localPath = null)
        {
            return DoDownloadActionAsync(documentNumber, action, localPath).Result;
        }

        protected async Task<byte[]> DoDownloadActionAsync(string documentNumber, Action action, string localPath = null)
        {
            if (!IsDownloadAction(action))
                throw new Exception("Invalid action type");

            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new[] { documentNumber, action.GetStringValue() },
                Method = HttpMethod.Get,
            };

            var data = await DoSimpleRequest().ConfigureAwait(false);
            if (localPath != null)
                await data.ToFile(localPath).ConfigureAwait(false);
            return data;
        }

        protected async Task<TEntity> DoActionAsync(string documentNumber, Action action)
        {
            if (IsDownloadAction(action))
                throw new Exception("Invalid action type");

            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new [] { documentNumber, action.GetStringValue() }
            };

            switch (action)
            {
                case Action.ExternalPrint:
                    RequestInfo.Method = HttpMethod.Put;
                    break;
                case Action.Email:
                    RequestInfo.Method = HttpMethod.Get;
                    break;
                default:
                    RequestInfo.Method = HttpMethod.Put;
                    break;
            }

            var result = await DoEntityRequest<EntityWrapper<TEntity>>().ConfigureAwait(false);
            return result?.Entity;
        }

        private static bool IsDownloadAction(Action action)
        {
            switch (action)
            {
                case Action.Print:
                case Action.PrintReminder:
                case Action.Preview:
                case Action.EPrint:
                    return true;
                default:
                    return false;
            }
        }
    }

    public enum Action
    {
        [EnumMember(Value = "print")]
        Print,
        [EnumMember(Value = "preview")]
        Preview,
        [EnumMember(Value = "eprint")]
        EPrint,
        [EnumMember(Value = "externalprint")]
        ExternalPrint,
        [EnumMember(Value = "email")]
        Email,
        [EnumMember(Value = "finish")]
        Finish,
        [EnumMember(Value = "createinvoice")]
        CreateInvoice,
        [EnumMember(Value = "increaseinvoicecount")]
        IncreaseInvoiceCount,
        [EnumMember(Value = "bookkeep")]
        Bookkeep,
        [EnumMember(Value = "cancel")]
        Cancel,
        [EnumMember(Value = "credit")]
        Credit,
        [EnumMember(Value = "printreminder")]
        PrintReminder,
        [EnumMember(Value = "approvalbookkeep")]
        ApprovalBookkeep,
        [EnumMember(Value = "approvalpayment")]
        ApprovalPayment,
        [EnumMember(Value = "einvoice")]
        EInvoice,
        [EnumMember(Value = "createorder")]
        CreateOrder
    }
}
