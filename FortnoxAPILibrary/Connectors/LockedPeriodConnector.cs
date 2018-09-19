using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FortnoxAPILibrary
{
    public interface ILockedPeriodConnector : IEntityConnector<Sort.By.LockedPeriod>
    {
        /// <summary>
        /// Gets the locked period setting
        /// </summary>
        /// <returns>The locked period setting</returns>
        LockedPeriod Get();
    }

    /// <remarks/>
    public class LockedPeriodConnector : EntityConnector<LockedPeriod, LockedPeriod, Sort.By.LockedPeriod>, ILockedPeriodConnector
    {
        /// <remarks/>
        public LockedPeriodConnector()
        {
            base.Resource = "settings/lockedperiod";
        }

        /// <summary>
        /// Gets the locked period setting
        /// </summary>
        /// <returns>The locked period setting</returns>
        public LockedPeriod Get()
        {
            return base.BaseFind();
        }
    }
}
