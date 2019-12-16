using System;

namespace FortnoxAPILibrary.Serialization
{
    internal class EntityAttribute : Attribute
    {
        public string SingularName { get; set; }
        public string PluralName { get; set; }
    }
}