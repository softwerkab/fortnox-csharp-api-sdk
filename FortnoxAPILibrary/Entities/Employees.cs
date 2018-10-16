using System.Collections.Generic;
using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <inheritdoc />
    [XmlRoot(ElementName = "EmployeeSubset")]
    public class EmployeeSubset : Employee
    {
        /// <summary>
        /// Full url to employee
        /// </summary>
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot(ElementName = "Employees")]
    public class Employees : PagedResult
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "EmployeeSubset")]
        public List<EmployeeSubset> EmployeeSubset { get; set; }
    }
}
