using System.ComponentModel;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    public class LockedPeriod
    {
        /// <remarks/>
        [ReadOnly(true)]
        public string EndDate { get; set; }
    }
}
