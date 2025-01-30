using System;
using Fortnox.SDK.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Fortnox.SDK.Entities;

[Entity(SingularName = "Account", PluralName = "Accounts")]
public class Account
{

    ///<summary> Direct URL to the record </summary>
    [ReadOnly]
    [JsonProperty("@url")]
    public Uri Url { get; private set; }

    ///<summary> If the account is actve </summary>
    [JsonProperty]
    public bool? Active { get; set; }

    ///<summary> Opening balance of the account </summary>
    [JsonProperty]
    public decimal? BalanceBroughtForward { get; set; }

    ///<summary> Closing balance of the account </summary>
    [ReadOnly]
    [JsonProperty]
    public decimal? BalanceCarriedForward { get; private set; }

    ///<summary> Code of the proposed cost center. The code must be of an existing cost center. </summary>
    [JsonProperty]
    public string CostCenter { get; set; }

    ///<summary> Cost center settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED </summary>
    [JsonProperty]
    public CostCenterSettings? CostCenterSettings { get; set; }

    ///<summary> Account description </summary>
    [JsonProperty]
    public string Description { get; set; }

    ///<summary> Account number </summary>
    [JsonProperty]
    public long? Number { get; set; }

    ///<summary> Opening quantities </summary>
    [JsonProperty]
    public IList<OpeningQuantity> OpeningQuantities { get; set; }

    ///<summary> Number of the proposed project. The number must be of an existing project. </summary>
    [JsonProperty]
    public string Project { get; set; }

    ///<summary> Project settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED </summary>
    [JsonProperty]
    public ProjectSettings? ProjectSettings { get; set; }

    ///<summary> Quantity settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED </summary>
    [ReadOnly]
    [JsonProperty]
    public QuantitySettings? QuantitySettings { get; private set; }

    ///<summary> Quantity unit </summary>
    [ReadOnly]
    [JsonProperty]
    public string QuantityUnit { get; private set; }

    ///<summary> SRU code </summary>
    [JsonProperty]
    public long? SRU { get; set; }

    ///<summary> Proposed transaction information </summary>
    [JsonProperty]
    public string TransactionInformation { get; set; }

    ///<summary> Transaction information settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED </summary>
    [JsonProperty]
    public TransactionInformationSettings? TransactionInformationSettings { get; set; }

    ///<summary> VAT code </summary>
    [JsonProperty]
    public string VATCode { get; set; }

    ///<summary> Id of the financial year. </summary>
    [ReadOnly]
    [JsonProperty]
    public long? Year { get; private set; }
}