using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public abstract class EntityConnector<TEntity, TEntityCollection, TSort> : UrlRequestBase where TEntity : class
    {
        /// <summary>
        /// Sort Order, ascending or descending
        /// </summary>
        [SearchParameter]
        public Sort.Order? SortOrder { get; set; }

        /// <summary>
        /// Sort the result
        /// </summary>
        [SearchParameter]
        public TSort SortBy { get; set; }

        /// <summary>
        /// <para>Use with Find() to limit the search result</para>
        /// <para>Default is 100</para>
        /// <para>Max is 500</para>
        /// </summary>
        [SearchParameter]
        public int? Limit { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public DateTime? LastModified { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public int? Page { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
        public int? Offset { get; set; }

        protected Dictionary<string, string> ParametersInjection { get; set; } //TODO: Remove, temporary workaround

        protected async Task<TEntity> BaseCreate(TEntity entity)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = Array.Empty<string>(),
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = RequestMethod.Post,
                ResponseType = RequestResponseType.JSON
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            var result = await DoEntityRequest(wrappedEntity);
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
                Method = RequestMethod.Put,
                ResponseType = RequestResponseType.JSON
            };
            ParametersInjection = null;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };

            var result = await DoEntityRequest(wrappedEntity);
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
                Method = RequestMethod.Delete,
                ResponseType = RequestResponseType.JSON,
            };
            ParametersInjection = null;

            await DoRequest();
        }

        protected async Task<TEntity> BaseGet(params string[] indices)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = indices,
                Parameters = ParametersInjection ?? new Dictionary<string, string>(),
                Method = RequestMethod.Get,
                ResponseType = RequestResponseType.JSON
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<EntityWrapper<TEntity>>();
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
                Method = RequestMethod.Get,
                ResponseType = RequestResponseType.JSON
            };
            ParametersInjection = null;

            var result = await DoEntityRequest<TEntityCollection>();
            return result;
        }

        protected Dictionary<string, string> GetSearchParameters()
        {
            var searchParams = new Dictionary<string, string>();

            foreach (var property in GetType().GetProperties())
            {
                var isSearchParameter = property.HasAttribute<SearchParameter>();
                if (!isSearchParameter) continue;

                var value = property.GetValue(this);
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
                return ((DateTime)value).ToString(APIConstants.DateAndTimeFormat);

            return value.ToString().ToLower();
        }

        protected TEntity DoAction(string documentNumber, Action action)
        {
            return DoActionAsync(documentNumber, action).Result;
        }

        protected async Task<TEntity> DoActionAsync(string documentNumber, Action action)
        {
            RequestInfo = new RequestInfo()
            {
                BaseUrl = BaseUrl,
                Resource = Resource,
                Indices = new [] { documentNumber, action.GetStringValue() }
            };

            switch (action)
            {
                case Action.Print:
                case Action.Preview:
                case Action.EPrint:
                    RequestInfo.Method = RequestMethod.Get;
                    RequestInfo.ResponseType = RequestResponseType.PDF;
                    break;
                case Action.ExternalPrint:
                    RequestInfo.Method = RequestMethod.Put;
                    RequestInfo.ResponseType = RequestResponseType.JSON;
                    break;
                case Action.Email:
                    RequestInfo.Method = RequestMethod.Get;
                    RequestInfo.ResponseType = RequestResponseType.Email;
                    break;
                default:
                    RequestInfo.Method = RequestMethod.Put;
                    break;
            }

            var result = await DoEntityRequest<EntityWrapper<TEntity>>();
            return result?.Entity;
        }
    }

    public enum Action
    {
        [StringValue("print")]
        Print,
        [StringValue("preview")]
        Preview,
        [StringValue("eprint")]
        EPrint,
        [StringValue("externalprint")]
        ExternalPrint,
        [StringValue("email")]
        Email,
        [StringValue("finish")]
        Finish,
        [StringValue("createinvoice")]
        CreateInvoice,
        [StringValue("increaseinvoicecount")]
        IncreaseInvoiceCount,
        [StringValue("bookkeep")]
        Bookkeep,
        [StringValue("cancel")]
        Cancel,
        [StringValue("credit")]
        Credit,
        [StringValue("printreminder")]
        PrintReminder,
        [StringValue("approvalbookkeep")]
        ApprovalBookkeep,
        [StringValue("approvalpayment")]
        ApprovalPayment,
        [StringValue("einvoice")]
        EInvoice,
        [StringValue("createorder")]
        CreateOrder
    }
}
