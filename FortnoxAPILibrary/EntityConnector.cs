using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace FortnoxAPILibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEntityConnector
    {
        /// <remarks/>
        FortnoxError.ErrorInformation Error { get; set; }

        /// <summary>
        /// True if something went wrong with the request. Otherwise false.
        /// </summary>
        bool HasError { get; }
    }

    /// <remarks />
    public abstract class EntityConnector<TEntity, TCollection, TSortBy> : UrlRequestBase, IEntityConnector
    {
        /// <remarks/>
        public EntityConnector()
        {
            LastModified = DateTime.MinValue;

            Error = null;

        }

        private TSortBy sortBy;
        private bool sortBySet = false;
        private string SortByRealValue
        {
            get
            {
                if (!sortBySet)
                {
                    return null;
                }

                Type type = this.SortBy.GetType();
                MemberInfo[] memInfo = type.GetMember(this.SortBy.ToString());
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(RealValueAttribute), false);
                if (attrs.Length > 0)
                {
                    return ((RealValueAttribute)attrs[0]).RealValue;
                }
                else
                {
                    return this.SortBy.ToString();
                }
            }
        }

        /// <summary>
        /// Sort Order, ascending or descending
        /// </summary>
        public Sort.Order SortOrder { get; set; }

        /// <summary>
        /// Sort the result
        /// </summary>
        public TSortBy SortBy
        {
            get
            {
                return sortBy;
            }
            set
            {
                sortBy = value;
                sortBySet = true;
            }
        }

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
            this.Parameters = parameters == null ? new Dictionary<string, string>() : parameters;

            string requestUriString = this.GetUrl();

            ResetProperties(entity);

            AddCustomParameters();

            requestUriString = AddParameters(requestUriString);

            base.Method = "POST";
            base.ResponseType = RequestResponseType.XML;
            base.RequestUriString = requestUriString;

            return base.DoRequest<TEntity>(entity);
        }

        internal TEntity BaseUpdate(TEntity entity, params string[] indices)
        {
            this.Parameters = new Dictionary<string, string>();

            string searchValue = String.Join("/", indices.Select(i => HttpUtility.UrlEncode(i)));

            string requestUriString = this.GetUrl(searchValue);

            ResetProperties(entity);

            AddCustomParameters();

            requestUriString = AddParameters(requestUriString);

            base.Method = "PUT";
            base.ResponseType = RequestResponseType.XML;
            base.RequestUriString = requestUriString;

            return base.DoRequest<TEntity>(entity);
        }

        internal void BaseDelete(string index)
        {
            this.Parameters = new Dictionary<string, string>();

            string requestUriString = this.GetUrl(index);

            requestUriString = AddParameters(requestUriString);

            base.Method = "DELETE";
            base.ResponseType = RequestResponseType.XML;
            base.RequestUriString = requestUriString;

            base.DoRequest();
        }

        internal TEntity BaseGet(params string[] indices)
        {
            this.Parameters = new Dictionary<string, string>();

            this.AddCustomParameters();

            string searchValue = String.Join("/", indices.Select(i => HttpUtility.UrlEncode(i)));

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                throw new Exception("Ett sökvärde har inte angivits.");
            }

            string requestUriString = this.GetUrl(searchValue);

            requestUriString = AddParameters(requestUriString);

            base.Method = "GET";
            base.ResponseType = RequestResponseType.XML;
            base.RequestUriString = requestUriString;

            return base.DoRequest<TEntity>();
        }

        internal TCollection BaseFind(Dictionary<string, string> parameters = null)
        {
            this.Parameters = parameters == null ? new Dictionary<string, string>() : parameters;

            this.AddCustomParameters();

            string requestUriString = this.GetUrl();

            if (this.Limit != 0)
            {
                this.Parameters.Add("limit", this.Limit.ToString());
            }

            if (this.LastModified != DateTime.MinValue)
            {
                
                this.Parameters.Add("lastmodified", this.LastModified.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            if (this.SortByRealValue != null)
            {
                this.Parameters.Add("sortby", this.SortByRealValue);
                this.Parameters.Add("sortorder", this.SortOrder.ToString().ToLower());
            }

            if (this.Page != 0)
            {
                this.Parameters.Add("page", this.Page.ToString());
            }

            if (this.Offset != 0)
            {
                this.Parameters.Add("offset", this.Offset.ToString());
            }

            requestUriString = this.AddParameters(requestUriString);

            base.Method = "GET";
            base.ResponseType = RequestResponseType.XML;
            base.RequestUriString = requestUriString;

            TCollection result = base.DoRequest<TCollection>();

            return result;
        }

        protected void AddCustomParameters()
        {
            var properties = this.GetType().GetProperties();

            foreach (var property in properties)
            {
                var customAttributes = property.GetCustomAttributes(typeof(FilterProperty), true);

                if (!customAttributes.Any()) continue;

                object value = property.GetValue(this, null);

                if (value == null) continue;

                string strValue;

                if (value is string)
                {
                    strValue = value as string;
                }
                else
                {
                    strValue = value.ToString().ToLower();
                }

                if (String.IsNullOrWhiteSpace(strValue)) continue;

                string propertyName;

                var filterPropertyAttribute = customAttributes.FirstOrDefault() as FilterProperty;

                if (filterPropertyAttribute == null || String.IsNullOrWhiteSpace(filterPropertyAttribute.Name))
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

                    var attribute = member.GetCustomAttributes(typeof(RealValueAttribute), true).FirstOrDefault() as RealValueAttribute;

                    if (attribute != null)
                    {
                        strValue = attribute.RealValue;
                    }
                }

                string propertySetName = property.Name[0].ToString().ToLower() + property.Name.Substring(1) + "Set";

                var propertySet = this.GetType().GetField(propertySetName, BindingFlags.NonPublic | BindingFlags.Instance);

                if (propertySet != null)
                {
                    if (!(bool)propertySet.GetValue(this))
                    {
                        continue;
                    }
                }

                this.Parameters.Add(propertyName.ToLower(), strValue);
            }
        }

        internal TEntity DoAction(string documentNumber, string action)
        {

            string requestUriString = this.GetUrl(documentNumber.ToString());

            requestUriString = requestUriString + "/" + action;

            requestUriString = AddParameters(requestUriString);


            if (action == "print" || action == "preview" || action == "eprint")
            {
                base.Method = "GET";
                base.ResponseType = RequestResponseType.PDF;
            }
            else if (action == "externalprint")
            {
                base.Method = "PUT";
                base.ResponseType = RequestResponseType.XML;

            }
            else if (action == "email")
            {
                base.Method = "GET";
                base.ResponseType = RequestResponseType.EMAIL;
            }
            else
            {
                base.Method = "PUT";
            }
            base.RequestUriString = requestUriString;

            return base.DoRequest<TEntity>();
        }


        internal SieSummary BaseUploadFile(string localPath)
        {
            string requestUriString = this.GetUrl();
            base.RequestUriString = AddParameters(requestUriString);

            return base.UploadFile<SieSummary>(localPath);
        }

        internal File BaseUploadFile(string localPath, string folderId, byte[] fileData = null, string fileName = null)
        {
            base.RequestUriString = this.GetUrl();

            if (!String.IsNullOrWhiteSpace(folderId))
            {
                base.RequestUriString += "?folderid=" + Uri.EscapeDataString(folderId);
            }

            return base.UploadFile<File>(localPath, fileData, fileName);
        }

        internal string AddParameters(string requestUriString)
        {
            if (this.Parameters.Count > 0)
            {
                requestUriString += "/?" + String.Join("&", this.Parameters.Select(p => p.Key + "=" + HttpUtility.UrlEncode(p.Value)));
            }

            return requestUriString;
        }


        private static void ResetProperties(TEntity entity)
        {
            //Nullar alla properties som har attibutet [ReadOnly(true)] eftersom de inte ska med i anropet. Kräver att alla properties är strängar
            var properties = typeof(TEntity).GetProperties().AsEnumerable();

            ResetProperties(entity, properties);
        }

        private static void ResetProperties(object obj, IEnumerable<PropertyInfo> properties)
        {
            properties = properties.Where(p => !p.PropertyType.IsEnum);

            foreach (PropertyInfo propertyInfo in properties)
            {
                var a = from aa in propertyInfo.GetCustomAttributes(true)
                        where aa is ReadOnlyAttribute
                        select aa;

                if (a.Any())
                {
                    propertyInfo.SetValue(obj, null, null);
                }

                if (obj != null)
                {
                    // Check if the property is a subclass
                    IEnumerable<PropertyInfo> subProperties = GetSubClassProperties(propertyInfo);

                    if (IsList(obj))
                    {
                        for (int i = 0; i < (int)obj.GetValue("Count"); i++)
                        {
                            ResetProperties(GetItemAtIndex(obj, propertyInfo, i), subProperties);
                        }
                    }
                    else if (subProperties.Count() > 0)
                    {
                        ResetProperties(propertyInfo.GetValue(obj, null), subProperties);
                    }
                }
            }
        }

        private static object GetItemAtIndex(object obj, PropertyInfo propertyInfo, int i)
        {
            return propertyInfo.GetValue(obj, new object[] { i });
        }

        private static bool IsList(object obj)
        {
            return typeof(List<>).Name == obj.GetType().Name;
        }

        private static IEnumerable<PropertyInfo> GetSubClassProperties(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.GetProperties().Where(p => p.PropertyType.GetProperties().Length > 0);
        }
    }
}
