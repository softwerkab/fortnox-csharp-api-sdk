using System.Collections;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FortnoxAPILibrary.Serialization
{
    internal class JsonEntitySerializer
    {
        private readonly JsonSerializerSettings settings;

        public JsonEntitySerializer()
        {
            settings = new JsonSerializerSettings();
            settings.DateFormatString = "yyyy-MM-dd";
            settings.Converters.Add(new StringEnumConverter());
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.ContractResolver = new MyJsonContractResolver(settings);
        }

        public string Serialize<T>(T entity)
        {
            return JsonConvert.SerializeObject(entity, settings);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        private class MyJsonContractResolver : DefaultContractResolver
        {
            private readonly JsonSerializerSettings settings;

            public MyJsonContractResolver(JsonSerializerSettings settings)
            {
                this.settings = settings;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                var isReadOnly = member.HasAttribute<ReadOnlyAttribute>();
                property.ShouldSerialize = o => !isReadOnly && !HasEmptyObjectValue(o, (PropertyInfo)member);

                var hasGenericName = member.HasAttribute<GenericPropertyNameAttribute>();

                if (hasGenericName)
                {
                    var propertyType = ((PropertyInfo)member).PropertyType;
                    if (propertyType.GetInterfaces().Contains(typeof(IEnumerable))) //is collection
                    {
                        var entityType = propertyType.GetGenericArguments()[0];
                        var entityAtt = entityType.GetAttribute<EntityAttribute>();
                        if (entityAtt?.SingularName != null)
                            property.PropertyName = entityAtt.PluralName;
                    }
                    else //single 
                    {
                        var entityType = propertyType;

                        var entityAtt = entityType.GetAttribute<EntityAttribute>();
                        if (entityAtt?.SingularName != null)
                            property.PropertyName = entityAtt.SingularName;
                    }
                }

                return property;
            }

            private bool HasEmptyObjectValue(object obj, PropertyInfo member)
            {
                var value = member.GetValue(obj);
                var json = JsonConvert.SerializeObject(value, settings);
                return json.Equals("{}"); //empty object
            }
        }
    }
}
