using FortnoxAPILibrary.Entities;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class LockedPeriodConnector : EntityConnector<LockedPeriod, LockedPeriod, Sort.By.LockedPeriod?>
    {
        /// <remarks/>
        public LockedPeriodConnector()
        {
            Resource = "settings/lockedperiod";
        }

        /// <summary>
        /// Gets the locked period setting
        /// </summary>
        /// <returns>The locked period setting</returns>
        public LockedPeriod Get()
        {
            return BaseFind();
        }
    }
}
