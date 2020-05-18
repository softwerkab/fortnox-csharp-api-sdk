using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum CustomerVATType
    {
        [EnumMember(Value = "SEVAT")]
        SE_VAT,
        [EnumMember(Value = "SEREVERSEDVAT")]
        SE_ReversedVAT,
        [EnumMember(Value = "EUREVERSEDVAT")]
        EU_ReversedVAT,
        [EnumMember(Value = "EUVAT")]
        EU_VAT,
        [EnumMember(Value = "EXPORT")]
        Export,
    }
}