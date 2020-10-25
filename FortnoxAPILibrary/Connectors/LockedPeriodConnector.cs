using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LockedPeriodConnector : EntityConnector<LockedPeriod, EntityWrapper<LockedPeriod>>, ILockedPeriodConnector
	{
		public LockedPeriodSearch Search { get; set; } = new LockedPeriodSearch();


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
            return (await BaseFind().ConfigureAwait(false))?.Entity;
        }
    }
}
