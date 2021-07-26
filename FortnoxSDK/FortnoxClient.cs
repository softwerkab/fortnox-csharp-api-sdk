using System.Net;
using Fortnox.SDK.Connectors.Base;
using System.Net.Http;
using Fortnox.SDK.Authorization;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Interfaces;

namespace Fortnox.SDK
{
    /// <summary>
    /// Entry point for Fortnox API usage.
    /// </summary>
    public class FortnoxClient
    {
        /// <summary>
        /// Default HttpClient instance
        /// </summary>
        internal static readonly HttpClient HttpClientSharedInstance = new HttpClient();

        /// <summary>
        /// Http client used under-the-hood for all request
        /// </summary>
        public HttpClient HttpClient { get; set; } = HttpClientSharedInstance;

        /// <summary>
        /// Authorization (credentials) for accessing Fortnox API
        /// </summary>
        public FortnoxAuthorization Authorization { get; set; }

        /// <summary>
        /// RateLimiter throttles thread for each request, which prevents connection failure due to server side rate limit
        /// If set to false, TooManyRequest error can occur.
        /// </summary>
        public bool UseRateLimiter { get; set; } = true;

        public FortnoxClient()
        {
        }

        public FortnoxClient(FortnoxAuthorization authorization, bool useRateLimiter = true)
        {
            Authorization = authorization;
            UseRateLimiter = useRateLimiter;
        }

        public FortnoxClient(FortnoxAuthorization authorization, HttpClient httpClient, bool useRateLimiter = true)
        {
            Authorization = authorization;
            HttpClient = httpClient;
            UseRateLimiter = useRateLimiter;
        }

        private TConnector Get<TConnector>() where TConnector : BaseConnector, new()
        {
            return new TConnector()
            {
                Authorization = Authorization,
                HttpClient = HttpClient,
                UseRateLimiter = UseRateLimiter,
            };
        }

        public IAbsenceTransactionConnector AbsenceTransactionConnector => Get<AbsenceTransactionConnector>();
        public IAccountChartConnector AccountChartConnector => Get<AccountChartConnector>();
        public IAccountConnector AccountConnector => Get<AccountConnector>();
        public IArchiveConnector ArchiveConnector => Get<ArchiveConnector>();
        public IArticleConnector ArticleConnector => Get<ArticleConnector>();
        public IArticleFileConnectionConnector ArticleFileConnectionConnector => Get<ArticleFileConnectionConnector>();
        public IAssetConnector AssetConnector => Get<AssetConnector>();
        public IAssetFileConnectionConnector AssetFileConnectionConnector => Get<AssetFileConnectionConnector>();
        public IAssetTypesConnector AssetTypesConnector => Get<AssetTypesConnector>();
        public IAttendanceTransactionsConnector AttendanceTransactionsConnector => Get<AttendanceTransactionsConnector>();
        public ICompanyInformationConnector CompanyInformationConnector => Get<CompanyInformationConnector>();
        public ICompanySettingsConnector CompanySettingsConnector => Get<CompanySettingsConnector>();
        public IContractAccrualConnector ContractAccrualConnector => Get<ContractAccrualConnector>();
        public IContractConnector ContractConnector => Get<ContractConnector>();
        public IContractTemplateConnector ContractTemplateConnector => Get<ContractTemplateConnector>();
        public ICostCenterConnector CostCenterConnector => Get<CostCenterConnector>();
        public ICurrencyConnector CurrencyConnector => Get<CurrencyConnector>();
        public ICustomerConnector CustomerConnector => Get<CustomerConnector>();
        public IEmployeeConnector EmployeeConnector => Get<EmployeeConnector>();
        public IExpenseConnector ExpenseConnector => Get<ExpenseConnector>();
        public IFinancialYearConnector FinancialYearConnector => Get<FinancialYearConnector>();
        public IArchiveConnector InboxConnector => Get<InboxConnector>(); //Note: Uses same interface as ArchiveConnector
        public IInvoiceAccrualConnector InvoiceAccrualConnector => Get<InvoiceAccrualConnector>();
        public IInvoiceConnector InvoiceConnector => Get<InvoiceConnector>();
        public IInvoiceFileConnectionConnector InvoiceFileConnectionConnector => Get<InvoiceFileConnectionConnector>();
        public IInvoicePaymentConnector InvoicePaymentConnector => Get<InvoicePaymentConnector>();
        public ILabelConnector LabelConnector => Get<LabelConnector>();
        public ILockedPeriodConnector LockedPeriodConnector => Get<LockedPeriodConnector>();
        public IModeOfPaymentConnector ModeOfPaymentConnector => Get<ModeOfPaymentConnector>();
        public IOfferConnector OfferConnector => Get<OfferConnector>();
        public IOrderConnector OrderConnector => Get<OrderConnector>();
        public IPredefinedAccountsConnector PredefinedAccountsConnector => Get<PredefinedAccountsConnector>();
        public IPredefinedVoucherSeriesConnector PredefinedVoucherSeriesConnector => Get<PredefinedVoucherSeriesConnector>();
        public IPriceConnector PriceConnector => Get<PriceConnector>();
        public IPriceListConnector PriceListConnector => Get<PriceListConnector>();
        public IPrintTemplateConnector PrintTemplateConnector => Get<PrintTemplateConnector>();
        public IProjectConnector ProjectConnector => Get<ProjectConnector>();
        public ISalaryTransactionConnector SalaryTransactionConnector => Get<SalaryTransactionConnector>();
        public IScheduleTimesConnector ScheduleTimesConnector => Get<ScheduleTimesConnector>();
        public ISIEConnector SIEConnector => Get<SIEConnector>();
        public ISupplierConnector SupplierConnector => Get<SupplierConnector>();
        public ISupplierInvoiceAccrualConnector SupplierInvoiceAccrualConnector => Get<SupplierInvoiceAccrualConnector>();
        public ISupplierInvoiceConnector SupplierInvoiceConnector => Get<SupplierInvoiceConnector>();
        public ISupplierInvoiceExternalURLConnectionConnector SupplierInvoiceExternalURLConnectionConnector => Get<SupplierInvoiceExternalURLConnectionConnector>();
        public ISupplierInvoiceFileConnectionConnector SupplierInvoiceFileConnectionConnector => Get<SupplierInvoiceFileConnectionConnector>();
        public ISupplierInvoicePaymentConnector SupplierInvoicePaymentConnector => Get<SupplierInvoicePaymentConnector>();
        public ITaxReductionConnector TaxReductionConnector => Get<TaxReductionConnector>();
        public ITermsOfDeliveryConnector TermsOfDeliveryConnector => Get<TermsOfDeliveryConnector>();
        public ITermsOfPaymentConnector TermsOfPaymentConnector => Get<TermsOfPaymentConnector>();
        public ITrustedEmailDomainsConnector TrustedEmailDomainsConnector => Get<TrustedEmailDomainsConnector>();
        public ITrustedEmailSendersConnector TrustedEmailSendersConnector => Get<TrustedEmailSendersConnector>();
        public IUnitConnector UnitConnector => Get<UnitConnector>();
        public IVoucherConnector VoucherConnector => Get<VoucherConnector>();
        public IVoucherFileConnectionConnector VoucherFileConnectionConnector => Get<VoucherFileConnectionConnector>();
        public IVoucherSeriesConnector VoucherSeriesConnector => Get<VoucherSeriesConnector>();
        public IWayOfDeliveryConnector WayOfDeliveryConnector => Get<WayOfDeliveryConnector>();
    }
}
