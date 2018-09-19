
namespace FortnoxAPILibrary.Connectors
{
    /// <inheritdoc />
    public interface IAccountChartConnector : IEntityConnector<Sort.By.AccountChart>
    {
        /// <summary>
        /// Gets a list of account charts 
        /// </summary>
        /// <returns>A list of account charts</returns>
        AccountCharts Find();
    }

    /// <remarks/>
	public class AccountChartConnector : EntityConnector<AccountCharts, AccountCharts, Sort.By.AccountChart>, IAccountChartConnector
    {
        /// <remarks/>
        public AccountChartConnector()
        {
            base.Resource = "accountcharts";
        }

		/// <summary>
		/// Gets a list of account charts 
		/// </summary>
		/// <returns>A list of account charts</returns>
		public AccountCharts Find()
		{
			return base.BaseFind();
		}
	}
}
