using System;

namespace Fortnox.SDK.Serialization;

internal class EntityAttribute : Attribute
{
    public string SingularName { get; set; }
    public string PluralName { get; set; }
}