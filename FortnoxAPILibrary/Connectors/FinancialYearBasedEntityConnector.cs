// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public abstract class FinancialYearBasedEntityConnector<E, C, S> : EntityConnector<E, C, S>
    {
        private string financialYearDateValue;
        private bool financialYearDateSet = false;

        /// <summary>
        /// <para>Use FinancialYearDate to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [FilterProperty]
        public string FinancialYearDate
        {
            get
            {
                return financialYearDateValue;
            }
            set
            {
                financialYearDateValue = value;
                financialYearDateSet = true;
            }
        }

        private string financialYearIDValue;
        private bool financialYearIDSet = false;

        /// <summary>
        /// <para>Use FinancialYearID to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [FilterProperty("financialyear")]
        public string FinancialYearID
        {
            get
            {
                return financialYearIDValue;
            }
            set
            {
                financialYearIDValue = value;
                financialYearIDSet = true;
            }
        }
    }
}
