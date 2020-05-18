using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LockedPeriodConnector : EntityConnector<LockedPeriod, EntityWrapper<LockedPeriod>, Sort.By.LockedPeriod?>, ILockedPeriodConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.LockedPeriod? FilterBy { get; set; }


		/// <remarks/>
		public LockedPeriodConnector()
		{
			Resource = "settings/lockedperiod";
		}

        public LockedPeriod Get()
        {
			return GetAsync().Result;
        }

        public async Task<LockedPeriod> GetAsync()
        {
            return (await BaseFind())?.Entity;
        }
    }
}
