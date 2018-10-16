using System.Xml.Serialization;

namespace FortnoxAPILibrary.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PagedResult
    {
        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "TotalResources")]
        public int TotalResources { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "TotalPages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlAttribute(AttributeName = "CurrentPage")]
        public int CurrentPage { get; set; }
    }
}