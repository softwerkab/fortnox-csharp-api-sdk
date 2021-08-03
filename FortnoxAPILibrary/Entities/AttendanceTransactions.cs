using System.Collections.Generic;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <inheritdoc />
    [XmlRoot(ElementName = "AttendanceTransactionSubset")]
    public class AttendanceTransactionSubset : AttendanceTransaction
    {
        /// <summary>
        /// Full url to AttendanceTransaction
        /// </summary>
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    [XmlRoot(ElementName = "AttendanceTransactions")]
    public class AttendanceTransactions : PagedResult
    {
        /// <summary>
        ///
        /// </summary>
        [XmlElement(ElementName = "AttendanceTransactionSubset")]
        public List<AttendanceTransactionSubset> AttendanceTransactionSubset { get; set; }
    }
}