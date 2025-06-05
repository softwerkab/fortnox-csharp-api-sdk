namespace Fortnox.SDK;

internal static class Endpoints
{
    /// <summary>
    /// Fortnox API version.
    /// </summary>
    public const string Version = "3";

    public const string AbsenceTransactions = $"/{Version}/absencetransactions";
    public const string AccountCharts = $"/{Version}/accountcharts";
    public const string Accounts = $"/{Version}/accounts";
    public const string Archive = $"/{Version}/archive";
    public const string Articles = $"/{Version}/articles";
    public const string ArticleFileConnections = $"/{Version}/articlefileconnections";
    public const string Assets = $"/{Version}/assets";
    public const string AssetTypes = $"/{Version}/assets/types";
    public const string AssetFileConnections = $"/{Version}/assetfileconnections";
    public const string AttendanceTransactions = $"/{Version}/attendancetransactions";

    public const string CompanyInformation = $"/{Version}/companyinformation";
    public const string CompanySettings = $"/{Version}/settings/company";
    public const string ContractAccruals = $"/{Version}/contractaccruals";
    public const string Contracts = $"/{Version}/contracts";
    public const string ContractTemplates = $"/{Version}/contracttemplates";
    public const string CostCenters = $"/{Version}/costcenters";
    public const string Currencies = $"/{Version}/currencies";
    public const string Customers = $"/{Version}/customers";

    public const string Employees = $"/{Version}/employees";
    public const string Expenses = $"/{Version}/expenses";
    public const string FinancialYears = $"/{Version}/financialyears";

    public const string Inbox = $"/{Version}/inbox";
    public const string InvoiceAccruals = $"/{Version}/invoiceaccruals";
    public const string Invoices = $"/{Version}/invoices";
    public const string InvoiceFileConnections = "/api/fileattachments/attachments-v1";
    public const string InvoicePayments = $"/{Version}/invoicepayments";

    public const string Labels = $"/{Version}/labels";
    public const string LockedPeriods = $"/{Version}/settings/lockedperiod";
    public const string ModesOfPayments = $"/{Version}/modesofpayments";
    public const string Offers = $"/{Version}/offers";
    public const string Orders = $"/{Version}/orders";

    public const string PredefinedAccounts = $"/{Version}/predefinedaccounts";
    public const string PredefinedVoucherSeries = $"/{Version}/predefinedvoucherseries";
    public const string Prices = $"/{Version}/prices";
    public const string PriceLists = $"/{Version}/pricelists";
    public const string PrintTemplates = $"/{Version}/printtemplates";
    public const string Projects = $"/{Version}/projects";

    public const string SalaryTransactions = $"/{Version}/salarytransactions";
    public const string ScheduleTimes = $"/{Version}/scheduletimes";
    public const string SIE = $"/{Version}/sie";
    public const string StockBalance = "/api/warehouse/status-v1/stockbalance";
    public const string StockPoints = "/api/warehouse/stockpoints-v1";
    public const string Suppliers = $"/{Version}/suppliers";
    public const string SupplierInvoiceAcrruals = $"/{Version}/supplierinvoiceaccruals";
    public const string SupplierInvoices = $"/{Version}/supplierinvoices";
    public const string SupplierInvoiceExternalUrlConnections = $"/{Version}/supplierinvoiceexternalurlconnections";
    public const string SupplierFileConnections = $"/{Version}/supplierinvoicefileconnections";
    public const string SupplierInvoicePayments = $"/{Version}/supplierinvoicepayments";

    public const string TaxReductions = $"/{Version}/taxreductions";
    public const string TermsOfDelivery = $"/{Version}/termsofdeliveries";
    public const string TermsOfPayments = $"/{Version}/termsofpayments";
    public const string TrustedEmailDomains = $"/{Version}/emailtrusteddomains";
    public const string TrustedEmailSenders = $"/{Version}/emailsenders/trusted";

    public const string Units = $"/{Version}/units";
    public const string Vouchers = $"/{Version}/vouchers";
    public const string VoucherFileConnections = $"/{Version}/voucherfileconnections";
    public const string VoucherSeries = $"/{Version}/voucherseries";
    public const string WayOfDelivery = $"/{Version}/wayofdeliveries";

    public const string EmailSenders = $"/{Version}/emailsenders";

    public const string Profile = $"/{Version}/me";

    public const string Tenant = "/api/warehouse/tenants-v4";

    public const string CustomerReferences = $"/{Version}/customerreferences";
}
