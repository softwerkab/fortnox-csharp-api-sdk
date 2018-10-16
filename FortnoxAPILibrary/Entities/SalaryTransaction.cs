using System;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "SalaryTransaction", IsNullable = false)]
    public class SalaryTransaction
    {
        /// <summary>
        /// Unique employee-id, max-length 15. Required.
        /// </summary>
        [XmlElement(ElementName = "EmployeeId")]
        public string EmployeeId { get; set; }

        /// <summary>
        /// Salary code, max-length 6. Required.
        /// 
        /// You can get a list of usable salary codes from Register, Lönearter och koder, Lönearter by choosing
        /// one of two tables and printing (Utskrift in the toolbar). Depending on which salary code
        /// table(löneartstabell) that is set in the settings(Inställningar, Lön, Avtal för arbetare/tjänsteman – Allmänt)
        /// you can choose the salary code to use from either salary code table.Make sure to use the correct
        /// table that is used for the employee(Register, Personal, Anställning, Personaltyp) you want to sent
        /// the salary transaction for. Some salary codes do not exist in every table.
        /// </summary>
        [XmlElement(ElementName = "SalaryCode")]
        public string SalaryCode { get; set; }

        /// <summary>
        /// Unique row ID, Read-only
        /// </summary>
        [XmlElement(ElementName = "SalaryRow")]
        public int? SalaryRow { get; set; }

        /// <summary>
        /// Date, format YYYY-MM-DD. Required
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
    }
}
