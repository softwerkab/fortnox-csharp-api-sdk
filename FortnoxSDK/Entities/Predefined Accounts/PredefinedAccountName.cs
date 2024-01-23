namespace Fortnox.SDK.Entities;

public static class PredefinedAccountName
{
    #region Payment Accounts / Betalkonton
    /// <summary>
    /// Bankgiro
    /// </summary>
    public const string Bankgiro = "BG";
    /// <summary>
    /// Plusgiro
    /// </summary>
    public const string Plusgiro = "PG";
    /// <summary>
    /// Kontantbetalning
    /// </summary>
    public const string Cash = "CASH";
    /// <summary>
    /// Kontantbet. via kontokort
    /// </summary>
    public const string CashByCard = "CASHBYCARD";
    /// <summary>
    /// Autogiro
    /// </summary>
    public const string Autogiro = "AG";
    #endregion

    #region Purchase Accounts / Inköp
    /// <summary>
    /// Inköp
    /// </summary>
    public const string Purchases = "PURCASE";
    /// <summary>
    /// Leverantörsskuld
    /// </summary>
    public const string AccountsPayable = "SUPDEBT";
    /// <summary>
    /// Faktureringsavgift levfakt
    /// </summary>
    public const string PurchasesInvoiceFee = "SUPADMFEE";
    /// <summary>
    /// Frakt levfakt
    /// </summary>
    public const string PurchasesFreight = "SUPFREIGHT";
    /// <summary>
    /// Kassarabatt, erhållen
    /// </summary>
    public const string PurchasesCashDiscount = "CASHDISCOUNTIN";
    #endregion

    #region Sale Accounts / Försäljning
    /// <summary>
    /// Försäljning 25% vara
    /// </summary>
    public const string Sales25Goods = "SALES_25_SE";
    /// <summary>
    /// Försäljning 25% tjänst
    /// </summary>
    public const string Sales25Services = "SALES_25_SE2";
    /// <summary>
    /// Försäljning 12% vara
    /// </summary>
    public const string Sales12Goods = "SALES_12_SE";
    /// <summary>
    /// Försäljning 12% tjänst
    /// </summary>
    public const string Sales12Services = "SALES_12_SE2";
    /// <summary>
    /// Försäljning 6% vara
    /// </summary>
    public const string Sales6Goods = "SALES_6_SE";
    /// <summary>
    /// Försäljning 6% tjänst
    /// </summary>
    public const string Sales6Services = "SALES_6_SE2";
    /// <summary>
    /// Försäljning 0% vara
    /// </summary>
    public const string Sales0Goods = "SALES_0_SE";
    /// <summary>
    /// Försäljning 0% tjänst
    /// </summary>
    public const string Sales0Services = "SALES_0_SE2";
    /// <summary>
    /// Försäljning SE, omvänd skattskyldighet
    /// </summary>
    public const string SalesSEReverseCharge = "SALESCONSTR2";
    /// <summary>
    /// Försäljning EU vara, omvänd skattskyldighet
    /// </summary>
    public const string SalesEUGoodsReverseCharge = "SALESEUREV";
    /// <summary>
    /// Försäljning EU tjänst, omvänd skattskyldighet
    /// </summary>
    public const string SalesEUServicesReverseCharge = "SALESEUREV2";
    /// <summary>
    /// Försäljning EU vara, momspliktig
    /// </summary>
    public const string SalesEUGoodsVat = "SALESEUVAT";
    /// <summary>
    /// Försäljning EU tjänst, momspliktig
    /// </summary>
    public const string SalesEUServicesVat = "SALESEUVAT2";
    /// <summary>
    /// Försäljning Export vara
    /// </summary>
    public const string SalesExtraEUGoods = "SALESEXPORT";
    /// <summary>
    /// Försäljning Export tjänst
    /// </summary>
    public const string SalesExtraEUServices = "SALESEXPORT2";
    /// <summary>
    /// Kundfordran
    /// </summary>
    public const string AccountsReceivable = "CUSTCLAIM";
    /// <summary>
    /// Faktureringsavgift
    /// </summary>
    public const string SalesInvoiceFee = "ADMFEE";
    /// <summary>
    /// Frakt
    /// </summary>
    public const string SalesFreight = "FREIGHT";
    /// <summary>
    /// Kassarabatt, lämnad
    /// </summary>
    public const string SalesCashDiscount = "CASHDISCOUNTOUT";
    /// <summary>
    /// Påminnelseavgift
    /// </summary>
    public const string ReminderFee = "DEMAND";
    /// <summary>
    /// Dröjsmålsränta
    /// </summary>
    public const string PenaltyInterest = "INTEREST";
    /// <summary>
    /// Avrundning
    /// </summary>
    public const string Rounding = "ROUNDOFF";
    #endregion

    #region Vat Accounts / Moms
    /// <summary>
    /// Utgående Moms MP1 25%
    /// </summary>
    public const string SalesVat1 = "OUTVAT_MP1";
    /// <summary>
    /// Utgående Moms MP2 12%
    /// </summary>
    public const string SalesVat2 = "OUTVAT_MP2";
    /// <summary>
    /// Utgående Moms MP3 6%
    /// </summary>
    public const string SalesVat3 = "OUTVAT_MP3";
    /// <summary>
    /// Ingående moms
    /// </summary>
    public const string PurchasesVat = "INVAT";
    /// <summary>
    /// Vara unionsinternt förvärv debit
    /// </summary>
    public const string ReverseChargeGoodsEUDebit = "PRODUCT_DEB";
    /// <summary>
    /// Vara unionsinternt förvärv credit
    /// </summary>
    public const string ReverseChargeGoodsEUCredit = "PRODUCT_CRE";
    /// <summary>
    /// Tjänst unionsinternt förvärv debit
    /// </summary>
    public const string ReverseChargeServicesEUDebit = "SERVICE_DEB";
    /// <summary>
    /// Tjänst unionsinternt förvärv credit
    /// </summary>
    public const string ReverseChargeServicesEUCredit = "SERVICE_CRE";
    /// <summary>
    /// Inköp SE, omvänd skattskyldighet debit
    /// </summary>
    public const string ReverseChargeSEDebit = "CONSTRUCTION_DEB";
    /// <summary>
    /// Inköp SE, omvänd skattskyldighet credit
    /// </summary>
    public const string ReverseChargeSECredit = "CONSTRUCTION_CRE";
    #endregion

    #region Accrual Accounts / Periodisering
    /// <summary>
    /// Periodiseringskonto levfakt
    /// </summary>
    public const string AccrualAccountSupplierInvoice = "ACCRSINVOICE";
    /// <summary>
    /// Periodiseringskonto kundfakt
    /// </summary>
    public const string AccrualAccountCustomerInvoice = "ACCRINVOICE";
    /// <summary>
    /// Intäktskonto periodisering
    /// </summary>
    public const string AccruedIncome = "ACCRINCOME";
    /// <summary>
    /// Kostnadskonto periodisering
    /// </summary>
    public const string AccruedCost = "ACCRCOST";
    #endregion

    #region Other Accounts / Övrigt
    /// <summary>
    /// Valutakursvinster
    /// </summary>
    public const string ExchangeGain = "CURRENCYWIN";
    /// <summary>
    /// Valutakursförluster
    /// </summary>
    public const string ExchangeLoss = "CURRENCYLOSS";
    #endregion
}
