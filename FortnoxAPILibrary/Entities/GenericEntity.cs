using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public class EntityWrapper<T>
    {
        [GenericPropertyName]
        public T Entity { get; set; }
    }

    public class EntityCollection<T>
    {
        [GenericPropertyName]
        [JsonProperty]
        public List<T> Entities { get; set; }

        [JsonProperty]
        private MetaInformation MetaInformation { get; set; }

        /// <remarks/>
        public string TotalResources => MetaInformation.TotalResources;

        /// <remarks/>
        public string TotalPages => MetaInformation.TotalPages;

        /// <remarks/>
        public string CurrentPage => MetaInformation.CurrentPage;
    }

    public class MetaInformation
    {
        [JsonProperty("@TotalResources")]
        public string TotalResources { get; set; }

        [JsonProperty("@TotalPages")]
        public string TotalPages { get; set; }

        [JsonProperty("@CurrentPage")]
        public string CurrentPage { get; set; }
    }

    internal class MyJsonContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            var isReadOnly = member.GetCustomAttributes<ReadOnlyAttribute>().Any();
            property.ShouldSerialize = o => !isReadOnly && !HasEmptyObjectValue(o, (PropertyInfo)member);

            var hasGenericName = member.GetCustomAttributes<GenericPropertyNameAttribute>().FirstOrDefault() != null;

            if (hasGenericName)
            {
                var propertyType = ((PropertyInfo) member).PropertyType;
                if (propertyType.GetInterfaces().Contains(typeof(IEnumerable))) //is collection
                {
                    var entityType = propertyType.GetGenericArguments()[0];
                    var entityAtt = entityType.GetCustomAttributes<EntityAttribute>().FirstOrDefault();
                    if (entityAtt?.SingularName != null)
                        property.PropertyName = entityAtt.PluralName;
                }
                else //single 
                {
                    var entityType = propertyType;

                    var entityAtt = entityType.GetCustomAttributes<EntityAttribute>().FirstOrDefault();
                    if (entityAtt?.SingularName != null)
                        property.PropertyName = entityAtt.SingularName;
                }
            }

            return property;
        }

        private static bool HasEmptyObjectValue(object obj, PropertyInfo member)
        {
            var value = member.GetValue(obj);
            var json = JsonConvert.SerializeObject(value);
            return json.Equals("{}"); //empty object
        }
    }

    internal class ReadOnlyAttribute : Attribute
    {
    }

    internal class GenericPropertyNameAttribute : Attribute
    {
    }

    internal class EntityAttribute : Attribute
    {
        public string SingularName { get; set; }
        public string PluralName { get; set; }
    }
}
