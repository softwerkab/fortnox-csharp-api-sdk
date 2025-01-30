using Fortnox.SDK.Serialization;
using Newtonsoft.Json;
using System;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "AbsenceTransaction", PluralName = "AbsenceTransactions")]
public class AbsenceTransaction
{
    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> Unique employee-id </summary>
    [JsonProperty]
    public string EmployeeId { get; set; }

    ///<summary> Cause code </summary>
    [JsonProperty]
    public AbsenceCauseCode? CauseCode { get; set; }

    ///<summary> Date </summary>
    [JsonProperty]
    public DateTime? Date { get; set; }

    ///<summary> Extent in % </summary>
    [JsonProperty]
    public decimal? Extent { get; set; }

    ///<summary> Amount of hours </summary>
    [JsonProperty]
    public decimal? Hours { get; set; }

    ///<summary> Determiens whether or not the registrations is holiday entitling </summary>
    [JsonProperty]
    public bool? HolidayEntitling { get; set; }

    ///<summary> Cost Center </summary>
    [JsonProperty]
    public string CostCenter { get; set; }

    ///<summary> Project </summary>
    [JsonProperty]
    public string Project { get; set; }

    ///<summary> Id </summary>
    [ReadOnly]
    [JsonProperty("id")]
    public string Id { get; private set; }
}