using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

namespace Fortnox.SDK.Entities;

public class EntityWrapper<T>
{
    public EntityWrapper()
    {
    }

    public EntityWrapper(T entity)
    {
        Entity = entity;
    }

    [JsonProperty(Required = Required.Always)]
    [GenericPropertyName]
    public T Entity { get; set; }
}