using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Auth
{
    public enum Scope
    {
        [EnumMember(Value = "archive")]
        Archive,
        [EnumMember(Value = "article")]
        Article,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "assets")]
        Assets,
        [EnumMember(Value = "bookkeeping")]
        Bookkeeping,
        [EnumMember(Value = "companyinformation")]
        CompanyInformation,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "companylogo")]
        CompanyLogo,
        [EnumMember(Value = "connectfile")]
        ConnnectFile,
        [EnumMember(Value = "costcenter")]
        CostCenter,
        [EnumMember(Value = "currency")]
        Currency,
        [EnumMember(Value = "customer")]
        Customer,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "deletevoucher")]
        DeleteVoucher,
        [EnumMember(Value = "inbox")]
        Inbox,
        [EnumMember(Value = "invoice")]
        Invoice,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "noxfinanceinvoice")]
        NoxFinanceInvoice,
        [EnumMember(Value = "offer")]
        Offer,
        [EnumMember(Value = "order")]
        Order,
        [EnumMember(Value = "payment")]
        Payment,
        [EnumMember(Value = "price")]
        Price,
        [EnumMember(Value = "print")]
        Print,
        [EnumMember(Value = "project")]
        Project,
        [EnumMember(Value = "salary")]
        Salary,
        [EnumMember(Value = "settings")]
        Settings,
        [EnumMember(Value = "supplier")]
        Supplier,
        [EnumMember(Value = "supplierinvoice")]
        SupplierInvoice,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "warehouse")]
        Warehouse,
        [Obsolete("Not listed in https://developer.fortnox.se/general/scopes/")]
        [EnumMember(Value = "warehousecustomdocument")]
        WarehouseCustomDocument
    }
}
