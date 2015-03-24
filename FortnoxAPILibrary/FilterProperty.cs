using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    internal class FilterProperty : Attribute
    {
        public readonly string Name;

        public FilterProperty(string name)
        {
            this.Name = name;
        }

        public FilterProperty()
        {
            this.Name = null;
        }
    }
}
