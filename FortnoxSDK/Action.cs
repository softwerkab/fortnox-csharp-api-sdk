using System.Net.Http;
using System.Runtime.Serialization;

namespace Fortnox.SDK;

public enum Action
{
    [EnumMember(Value = "print")]
    Print,

    [EnumMember(Value = "preview")]
    Preview,

    [EnumMember(Value = "eprint")]
    EPrint,

    [EnumMember(Value = "externalprint")]
    ExternalPrint,

    [EnumMember(Value = "email")]
    Email,

    [EnumMember(Value = "finish")]
    Finish,

    [EnumMember(Value = "createinvoice")]
    CreateInvoice,

    [EnumMember(Value = "increaseinvoicecount")]
    IncreaseInvoiceCount,

    [EnumMember(Value = "bookkeep")]
    Bookkeep,

    [EnumMember(Value = "cancel")]
    Cancel,

    [EnumMember(Value = "credit")]
    Credit,

    [EnumMember(Value = "printreminder")]
    PrintReminder,

    [EnumMember(Value = "approvalbookkeep")]
    ApprovalBookkeep,

    [EnumMember(Value = "approvalpayment")]
    ApprovalPayment,

    [EnumMember(Value = "einvoice")]
    EInvoice,

    [EnumMember(Value = "createorder")]
    CreateOrder,

    [EnumMember(Value = "warehouseready")]
    WarehouseReady
}

public static class ActionExtensions
{
    public static bool IsDownloadAction(this Action action)
    {
        switch (action)
        {
            case Action.Print:
            case Action.PrintReminder:
            case Action.Preview:
                return true;
            default:
                return false;
        }
    }

    public static HttpMethod GetMethod(this Action action)
    {
        switch (action)
        {
            case Action.ExternalPrint:
                return HttpMethod.Put;
            case Action.Email:
            case Action.EInvoice:
            case Action.EPrint:
                return HttpMethod.Get;
            default:
                return HttpMethod.Put;
        }
    }
}