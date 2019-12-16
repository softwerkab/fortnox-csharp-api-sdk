// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public abstract class FinancialYearBasedEntityConnector<TEntity, TEntityCollection, TSort> : EntityConnector<TEntity, TEntityCollection, TSort> where TEntity : class
    {
        /// <summary>
        /// <para>Use FinancialYearDate to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [SearchParameter]
        public string FinancialYearDate { get; set; }

        /// <summary>
        /// <para>Use FinancialYearID to select the financial year to use.</para>
        /// <para>If omitted the default financial year will be selected</para>
        /// </summary>
        [SearchParameter("financialyear")]
        public string FinancialYearID { get; set; }
    }
}
