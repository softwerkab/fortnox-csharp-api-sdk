using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "SalaryTransactionSubset")]
    public class SalaryTransactionSubset
    {
        /// <summary>
        /// Unique employee-id, max-length 15
        /// </summary>
        [XmlElement(ElementName = "EmployeeId")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Salary code, max-length 6
        /// </summary>
        [XmlElement(ElementName = "SalaryCode")]
        public string SalaryCode { get; set; }

        /// <summary>
        /// Unique row ID, Read-only
        /// </summary>
        [XmlElement(ElementName = "SalaryRow")]
        public int SalaryRow { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        [XmlElement(ElementName = "Date")]
        public string Date { get; set; }

        /// <summary>
        /// Number of #
        /// </summary>
        [XmlElement(ElementName = "Number")]
        public double Number { get; set; }

        /// <summary>
        /// Cost per # in SEK
        /// </summary>
        [XmlElement(ElementName = "Amount")]
        public double Amount { get; set; }

        /// <summary>
        /// Sum in SEK
        /// </summary>
        [XmlElement(ElementName = "Total")]
        public double Total { get; set; }

        /// <summary>
        /// Expense code from the expense registry, max-length 6
        /// </summary>
        [XmlElement(ElementName = "Expense")]
        public string Expense { get; set; }

        /// <summary>
        /// Sum VAT
        /// </summary>
        [XmlElement(ElementName = "VAT")]
        public double Vat { get; set; }

        /// <summary>
        /// Optional additional text relating to the salary transaction, max-length 40
        /// </summary>
        [XmlElement(ElementName = "TextRow")]
        public string TextRow { get; set; }

        /// <summary>
        /// Url of the full salary transaction
        /// </summary>
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "SalaryTransactions")]
    public class SalaryTransactions : PagedResult
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "SalaryTransactionSubset")]
        public List<SalaryTransactionSubset> SalaryTransactionSubset { get; set; }
    }
}
