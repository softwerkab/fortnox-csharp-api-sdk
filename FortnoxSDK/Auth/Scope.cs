﻿using System;
using System.Runtime.Serialization;

namespace Fortnox.SDK.Auth;

/// <summary>
/// Fortnox OAuth scopes.
///
/// Scopes is the access an app has to the Fortnox API.
///
/// An app can request one or more scopes, this information is then presented
/// to the user in the consent screen, and the access token issued to the
/// connection will be limited to the scopes granted.
///
/// See https://www.fortnox.se/developer/guides-and-good-to-know/scopes
/// </summary>
public enum Scope
{
    [EnumMember(Value = "archive")]
    Archive,
    [EnumMember(Value = "article")]
    Article,
    [Obsolete("Not listed in https://www.fortnox.se/developer/guides-and-good-to-know/scopes")]
    [EnumMember(Value = "assets")]
    Assets,
    [EnumMember(Value = "bookkeeping")]
    Bookkeeping,
    [EnumMember(Value = "companyinformation")]
    CompanyInformation,
    [Obsolete("Not listed in https://www.fortnox.se/developer/guides-and-good-to-know/scopes")]
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
    [Obsolete("Not listed in https://www.fortnox.se/developer/guides-and-good-to-know/scopes")]
    [EnumMember(Value = "deletevoucher")]
    DeleteVoucher,
    [EnumMember(Value = "inbox")]
    Inbox,
    [EnumMember(Value = "invoice")]
    Invoice,
    [EnumMember(Value = "noxfinansinvoice")]
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
    [EnumMember(Value = "profile")]
    Profile,
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
    [EnumMember(Value = "timereporting")]
    TimeReporting,
    [Obsolete("Not listed in https://www.fortnox.se/developer/guides-and-good-to-know/scopes")]
    [EnumMember(Value = "warehouse")]
    Warehouse,
    [Obsolete("Not listed in https://www.fortnox.se/developer/guides-and-good-to-know/scopes")]
    [EnumMember(Value = "warehousecustomdocument")]
    WarehouseCustomDocument
}