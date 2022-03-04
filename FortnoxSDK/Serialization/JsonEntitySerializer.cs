using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using Fortnox.SDK.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Fortnox.SDK.Serialization;

internal class JsonEntitySerializer : ISerializer
{
    private readonly JsonSerializerSettings settings;
    
    public JsonEntitySerializer(bool warehouseEnabled = false)
    {
        settings = new JsonSerializerSettings();
        settings.DateFormatString = "yyyy-MM-dd";
        settings.Converters.Add(new StringEnumConverter());
        settings.NullValueHandling = NullValueHandling.Ignore;
        settings.ContractResolver = new MyJsonContractResolver(settings, warehouseEnabled);
    }

    public string Serialize<T>(T entity)
    {
        return JsonConvert.SerializeObject(entity, settings);
    }

    public T Deserialize<T>(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
            throw new Exception("Can not deserialize empty JSON.");

        return JsonConvert.DeserializeObject<T>(json, settings);
    }

    private class MyJsonContractResolver : DefaultContractResolver
    {
        private readonly JsonSerializerSettings settings;
        private readonly bool warehouseEnabled;

        public MyJsonContractResolver(JsonSerializerSettings settings, bool warehouseEnabled)
        {
            this.settings = settings;
            this.warehouseEnabled = warehouseEnabled;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            var warehouseRequired = member.HasAttribute<WarehouseRequiredAttribute>();
            var isDisabled = warehouseRequired && !warehouseEnabled;

            var isReadOnly = member.HasAttribute<ReadOnlyAttribute>();
            property.ShouldSerialize = o => !isDisabled && !isReadOnly && !HasEmptyObjectValue(o, (PropertyInfo)member);

            var hasGenericName = member.HasAttribute<GenericPropertyNameAttribute>();

            if (hasGenericName)
            {
                var propertyType = ((PropertyInfo)member).PropertyType;
                if (propertyType.GetInterfaces().Contains(typeof(IEnumerable))) // is collection
                {
                    var entityType = propertyType.GetGenericArguments()[0];
                    var entityAtt = entityType.GetAttribute<EntityAttribute>();
                    if (entityAtt?.SingularName != null)
                        property.PropertyName = entityAtt.PluralName;
                }
                else // single 
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
            return json.Equals("{}"); // empty object
        }
    }
}