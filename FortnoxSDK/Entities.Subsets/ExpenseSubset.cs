using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace Fortnox.SDK.Entities;

/// <remarks/>
[Entity(SingularName = "Expense", PluralName = "Expenses")]
public class ExpenseSubset : Expense
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }
}