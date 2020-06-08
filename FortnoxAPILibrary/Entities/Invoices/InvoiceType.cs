using System.Runtime.Serialization;

namespace FortnoxAPILibrary.Entities
{
    public enum InvoiceType
    {
        [EnumMember(Value = "INVOICE")]
        Invoice,
        [EnumMember(Value = "AGREEMENTINVOICE")]
        AgreementInvoice,
        [EnumMember(Value = "INTRESTINVOICE")]
        IntrestInvoice,
        [EnumMember(Value = "SUMMARYINVOICE")]
        SummaryInvoice,
        [EnumMember(Value = "CASHINVOICE")]
        CashInvoice,
    }
}