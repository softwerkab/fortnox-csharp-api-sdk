using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Entity(SingularName = "Account", PluralName = "Accounts")]
    public class AccountSubset
    {
        ///<summary> Direct URL to the record </summary>
        [ReadOnly]
        [JsonProperty("@url")]
        public string Url { get; private set; }

        ///<summary> If the account is actve </summary>
        [JsonProperty]
        public bool? Active { get; set; }

        ///<summary> Opening balance of the account </summary>
        [JsonProperty]
        public decimal? BalanceBroughtForward { get; set; }

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
        public int? Number { get; set; }

        ///<summary> Number of the proposed project. The number must be of an existing project. </summary>
        [JsonProperty]
        public string Project { get; set; }

        ///<summary> Project settings for the account. Can be ALLOWED MANDATORY or NOTALLOWED </summary>
        [JsonProperty]
        public ProjectSettings? ProjectSettings { get; set; }

        ///<summary> SRU code </summary>
        [JsonProperty]
        public int? SRU { get; set; }

        ///<summary> Id of the financial year. </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Year { get; private set; }
    }
}
