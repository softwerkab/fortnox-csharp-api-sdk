using Fortnox.SDK.Serialization;

namespace Fortnox.SDK.Entities
{
    public class EntityWrapper<T>
    {
        public EntityWrapper()
        {
        }

        public EntityWrapper(T entity)
        {
            Entity = entity;
        }

        [GenericPropertyName]
        public T Entity { get; set; }
    }
}
