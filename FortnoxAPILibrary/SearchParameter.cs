using System;

namespace FortnoxAPILibrary
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class SearchParameter : Attribute
    {
        public readonly string Name;

        public SearchParameter(string name = null)
        {
            Name = name;
        }
    }
}
