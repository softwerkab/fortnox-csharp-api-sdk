using System.Runtime.Serialization;

namespace Fortnox.SDK.Entities;

public enum ReferenceType
{
    [EnumMember(Value = "INVOICE")]
    Invoice,
    [EnumMember(Value = "SUPPLIERINVOICE")]
    SupplierInvoice,
    [EnumMember(Value = "INVOICEPAYMENT")]
    InvoicePayment,
    [EnumMember(Value = "SUPPLIERPAYMENT")]
    SupplierPayment,
    [EnumMember(Value = "MANUAL")]
    Manual,
    [EnumMember(Value = "CASHINVOICE")]
    CashInvoice,
    [EnumMember(Value = "ACCRUAL")]
    Accrual,

    //Not listed in official documentation
    [EnumMember(Value = "RECEIPT")]
    Receipt,
    [EnumMember(Value = "PAYROLLBOOKKEEP")]
    PayrollBookkeep,
}