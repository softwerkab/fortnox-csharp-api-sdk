using System;

namespace FortnoxAPILibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class FilterProperty : Attribute
    {
        public readonly string Name;

        public FilterProperty(string name)
        {
            Name = name;
        }

        public FilterProperty()
        {
            Name = null;
        }
    }
}
