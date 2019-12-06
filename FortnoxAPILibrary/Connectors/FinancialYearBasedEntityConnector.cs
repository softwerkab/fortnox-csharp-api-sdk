// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public abstract class FinancialYearBasedEntityConnector<E, C, S> : EntityConnector<E, C, S>
    {
        /// <summary>
        /// <para>Use FinancialYearDate to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [FilterProperty]
        public string FinancialYearDate { get; set; }

        /// <summary>
        /// <para>Use FinancialYearID to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [FilterProperty("financialyear")]
        public string FinancialYearID { get; set; }
    }
}
