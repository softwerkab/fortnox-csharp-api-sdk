using FortnoxAPILibrary.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    [Entity(SingularName = "VoucherRow", PluralName = "VoucherRows")]
    public class VoucherRow
    {

        ///<summary> Voucher number </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Number { get; private set; }

        ///<summary> Voucher year </summary>
        [ReadOnly]
        [JsonProperty]
        public int? Year { get; private set; }

        ///<summary> Voucher series </summary>
        [ReadOnly]
        [JsonProperty]
        public string Series { get; private set; }

        ///<summary> Reference type of the voucher </summary>
        [ReadOnly]
        [JsonProperty]
        public string ReferenceType { get; private set; }
    }
}