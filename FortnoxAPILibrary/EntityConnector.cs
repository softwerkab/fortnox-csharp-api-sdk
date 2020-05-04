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

        /// <remarks/>
        protected Dictionary<string, string> Parameters = new Dictionary<string, string>();

        protected Dictionary<string, string> BaseGetParametersInjection = new Dictionary<string, string>(); //TODO: Remove, only temporary workaround (BaseGet has no parameters injection)
        protected Dictionary<string, string> BaseDeleteParametersInjection = new Dictionary<string, string>(); //TODO: Remove, only temporary workaround (BaseGet has no parameters injection)

        protected async Task<TEntity> BaseCreate(TEntity entity, Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            var requestUriString = GetUrl();

            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Post;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            var result = await DoRequest(wrappedEntity);
            return result?.Entity;
        }

        protected async Task<TEntity> BaseUpdate(TEntity entity, params string[] indices)
        {
            Parameters = new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Put;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };

            var result = await DoRequest(wrappedEntity);
            return result?.Entity;
        }

        protected async Task BaseDelete(params string[] indices)
        {
            Parameters = new Dictionary<string, string>();
            Parameters = BaseDeleteParametersInjection;

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Delete;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            await DoRequest();
        }

        protected async Task<TEntity> BaseGet(params string[] indices)
        {
            Parameters = new Dictionary<string, string>();
            Parameters = BaseGetParametersInjection;

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Get;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = await DoRequest<EntityWrapper<TEntity>>();
            return result?.Entity;
        }

        protected async Task<TEntityCollection> BaseFind(Dictionary<string, string> parameters = null, params string[] indices)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            AddSearchParameters();
            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = RequestMethod.Get;
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = await DoRequest<TEntityCollection>();
            return result;
        }

        protected void AddSearchParameters()
        {
            foreach (var property in GetType().GetProperties())
            {
                var isSearchParameter = property.HasAttribute<SearchParameter>();
                if (!isSearchParameter) continue;

                var value = property.GetValue(this);
                var strValue = GetStringValue(value, property.PropertyType);
                if (string.IsNullOrWhiteSpace(strValue)) continue;

                var searchAttribute = property.GetAttribute<SearchParameter>();
                var paramName = searchAttribute.Name ?? property.Name;

                Parameters.Add(paramName.ToLower(), strValue);
            }
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

        protected TEntity DoAction(string documentNumber, string action)
        {
            return DoActionAsync(documentNumber, action).Result;
        }
        protected async Task<TEntity> DoActionAsync(string documentNumber, string action)
        {
            string requestUriString = GetUrl(documentNumber);

            requestUriString = requestUriString + "/" + action;

            requestUriString = AddParameters(requestUriString);


            switch (action)
            {
                case "print":
                case "preview":
                case "eprint":
                    Method = RequestMethod.Get;
                    ResponseType = RequestResponseType.PDF;
                    break;
                case "externalprint":
                    Method = RequestMethod.Put;
                    ResponseType = RequestResponseType.JSON;
                    break;
                case "email":
                    Method = RequestMethod.Get;
                    ResponseType = RequestResponseType.Email;
                    break;
                default:
                    Method = RequestMethod.Put;
                    break;
            }
            RequestUriString = requestUriString;

            var result = await DoRequest<EntityWrapper<TEntity>>();
            return result?.Entity;
        }
        
        protected string AddParameters(string requestUriString)
        {
            if (Parameters.Count > 0)
            {
                requestUriString += "/?" + string.Join("&", Parameters.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)));
            }

            return requestUriString;
        }
    }
}
