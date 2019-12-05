using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AccountChartConnector : EntityConnector<AccountCharts, AccountCharts, Sort.By.AccountChart>
	{
        /// <remarks/>
        public AccountChartConnector()
        {
            Resource = "accountcharts";
        }

		/// <summary>
		/// Gets a list of account charts 
		/// </summary>
		/// <returns>A list of account charts</returns>
		public AccountCharts Find()
		{
			return BaseFind();
		}
	}
}
