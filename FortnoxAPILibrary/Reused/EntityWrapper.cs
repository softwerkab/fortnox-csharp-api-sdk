using FortnoxAPILibrary.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public class EntityWrapper<T>
    {
        [GenericPropertyName]
        public T Entity { get; set; }
    }
}
