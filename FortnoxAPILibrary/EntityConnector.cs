using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        internal TEntity BaseCreate(TEntity entity, Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            var requestUriString = GetUrl();

            requestUriString = AddParameters(requestUriString);

            Method = "POST";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            return DoRequest(wrappedEntity)?.Entity;
        }

        internal TEntity BaseUpdate(TEntity entity, params string[] indices)
        {
            Parameters = new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = "PUT";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };
            return DoRequest(wrappedEntity)?.Entity;
        }

        internal void BaseDelete(string index)
        {
            Parameters = new Dictionary<string, string>();

            var requestUriString = GetUrl(index);

            requestUriString = AddParameters(requestUriString);

            Method = "DELETE";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            DoRequest();
        }

        internal TEntity BaseGet(params string[] indices)
        {
            Parameters = new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                throw new Exception("Ett sökvärde har inte angivits.");
            }

            var requestUriString = GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            Method = "GET";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = DoRequest<EntityWrapper<TEntity>>();
            return result?.Entity;
        }

        internal TEntityCollection BaseFind(Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            AddSearchParameters();

            var requestUriString = GetUrl();

            requestUriString = AddParameters(requestUriString);

            Method = "GET";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = DoRequest<TEntityCollection>();
            return result;
        }

        protected void AddSearchParameters()
        {
            foreach (var property in GetType().GetProperties())
            {
                var isSearchParameter = property.HasAttribute<SearchParameter>();
                if (!isSearchParameter) continue;

                var value = property.GetValue(this);
                if (value == null) continue;

                var strValue = value is string ? value.ToString() : value.ToString().ToLower();
                if (property.PropertyType.IsEnum)
                    strValue = ((Enum) value).GetStringValue();

                if (string.IsNullOrWhiteSpace(strValue)) continue;

                var searchAttribute = property.GetAttribute<SearchParameter>();
                var paramName = searchAttribute.Name ?? property.Name;

                Parameters.Add(paramName.ToLower(), strValue);
            }
        }

        internal TEntity DoAction(string documentNumber, string action)
        {

            string requestUriString = GetUrl(documentNumber);

            requestUriString = requestUriString + "/" + action;

            requestUriString = AddParameters(requestUriString);


            if (action == "print" || action == "preview" || action == "eprint")
            {
                Method = "GET";
                ResponseType = RequestResponseType.PDF;
            }
            else if (action == "externalprint")
            {
                Method = "PUT";
                ResponseType = RequestResponseType.JSON;

            }
            else if (action == "email")
            {
                Method = "GET";
                ResponseType = RequestResponseType.EMAIL;
            }
            else
            {
                Method = "PUT";
            }
            RequestUriString = requestUriString;

            var result = DoRequest<EntityWrapper<TEntity>>();
            return result?.Entity;
        }

        internal SieSummary BaseUploadFile(string localPath)
        {
            string requestUriString = GetUrl();
            RequestUriString = AddParameters(requestUriString);

            return UploadFile<SieSummary>(localPath);
        }

        internal File BaseUploadFile(string localPath, string folderId, byte[] fileData = null, string fileName = null)
        {
            RequestUriString = GetUrl();

            if (!string.IsNullOrWhiteSpace(folderId))
            {
                RequestUriString += "?folderid=" + Uri.EscapeDataString(folderId);
            }

            return UploadFile<File>(localPath, fileData, fileName);
        }

        internal string AddParameters(string requestUriString)
        {
            if (Parameters.Count > 0)
            {
                requestUriString += "/?" + string.Join("&", Parameters.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)));
            }

            return requestUriString;
        }
    }
}
