using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FortnoxAPILibrary.Entities;

namespace FortnoxAPILibrary
{
    /// <remarks/>
    public abstract class EntityConnector<TEntity, TEntityCollection, TSort> : UrlRequestBase
    {
        /// <remarks/>
        protected EntityConnector()
        {
            LastModified = DateTime.MinValue;
            Error = null;
        }

        private string SortByRealValue
        {
            get
            {
                if (SortBy == null)
                    return null;

                var type = SortBy.GetType();
                var memInfo = type.GetMember(SortBy.ToString());
                var attrs = memInfo[0].GetCustomAttributes(typeof(RealValueAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((RealValueAttribute)attrs[0]).RealValue;
                }

                return SortBy.ToString();
            }
        }

        /// <summary>
        /// Sort Order, ascending or descending
        /// </summary>
        public Sort.Order SortOrder { get; set; }

        /// <summary>
        /// Sort the result
        /// </summary>
        public TSort SortBy { get; set; }

        /// <summary>
        /// <para>Use with Find() to limit the search result</para>
        /// <para>Default is 100</para>
        /// <para>Max is 500</para>
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        public int Offset { get; set; }

        /// <remarks/>
        protected Dictionary<string, string> Parameters = new Dictionary<string, string>();

        internal TEntity BaseCreate(TEntity entity, Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            var requestUriString = GetUrl();

            AddCustomParameters();

            requestUriString = AddParameters(requestUriString);

            Method = "POST";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() {Entity = entity};
            return DoRequest(wrappedEntity).Entity;
        }

        internal TEntity BaseUpdate(TEntity entity, params string[] indices)
        {
            Parameters = new Dictionary<string, string>();

            var searchValue = string.Join("/", indices.Select(HttpUtility.UrlEncode));

            var requestUriString = GetUrl(searchValue);

            AddCustomParameters();

            requestUriString = AddParameters(requestUriString);

            Method = "PUT";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var wrappedEntity = new EntityWrapper<TEntity>() { Entity = entity };
            return DoRequest(wrappedEntity).Entity;
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

            AddCustomParameters();

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

            return DoRequest<EntityWrapper<TEntity>>().Entity;
        }

        internal TEntityCollection BaseFind(Dictionary<string, string> parameters = null)
        {
            Parameters = parameters ?? new Dictionary<string, string>();

            AddCustomParameters();

            var requestUriString = GetUrl();

            if (Limit != 0)
            {
                Parameters.Add("limit", Limit.ToString());
            }

            if (LastModified != DateTime.MinValue)
            {
                
                Parameters.Add("lastmodified", LastModified.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (SortByRealValue != null)
            {
                Parameters.Add("sortby", SortByRealValue);
                Parameters.Add("sortorder", SortOrder.ToString().ToLower());
            }

            if (Page != 0)
            {
                Parameters.Add("page", Page.ToString());
            }

            if (Offset != 0)
            {
                Parameters.Add("offset", Offset.ToString());
            }

            requestUriString = AddParameters(requestUriString);

            Method = "GET";
            ResponseType = RequestResponseType.JSON;
            RequestUriString = requestUriString;

            var result = DoRequest<TEntityCollection>();
            return result;
        }

        protected void AddCustomParameters()
        {
            var properties = GetType().GetProperties();

            foreach (var property in properties)
            {
                var customAttributes = property.GetCustomAttributes(typeof(FilterProperty), true);

                if (!customAttributes.Any()) continue;

                var value = property.GetValue(this, null);

                if (value == null) continue;

                var strValue = value is string ? value.ToString() : value.ToString().ToLower();

                if (string.IsNullOrWhiteSpace(strValue)) continue;

                string propertyName;

                var filterPropertyAttribute = customAttributes.FirstOrDefault() as FilterProperty;

                if (filterPropertyAttribute == null || string.IsNullOrWhiteSpace(filterPropertyAttribute.Name))
                {
                    propertyName = property.Name;
                }
                else
                {
                    propertyName = filterPropertyAttribute.Name;
                }

                if (property.PropertyType.IsEnum)
                {
                    var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();

                    if (member.GetCustomAttributes(typeof(RealValueAttribute), true).FirstOrDefault() is RealValueAttribute attribute)
                    {
                        strValue = attribute.RealValue;
                    }
                }

                string propertySetName = property.Name[0].ToString().ToLower() + property.Name.Substring(1) + "Set";

                var propertySet = GetType().GetField(propertySetName, BindingFlags.NonPublic | BindingFlags.Instance);

                if (propertySet != null)
                {
                    if (!(bool)propertySet.GetValue(this))
                    {
                        continue;
                    }
                }

                Parameters.Add(propertyName.ToLower(), strValue);
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

            return DoRequest<EntityWrapper<TEntity>>().Entity;
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
