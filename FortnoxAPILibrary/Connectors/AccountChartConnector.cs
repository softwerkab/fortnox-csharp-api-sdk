
namespace FortnoxAPILibrary.Connectors
{
	/// <remarks/>
	public class AccountChartConnector : EntityConnector<AccountCharts, AccountCharts, Sort.By.AccountChart>
	{
        /// <remarks/>
        public AccountChartConnector(string accessToken, string clientSecret) : base(accessToken, clientSecret)
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
