using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortnoxAPILibrary
{
    public class ParseXmlResponseException : Exception
    {
        public string ResponseContent { get; set; }

        public ParseXmlResponseException(string message, string responseContent, Exception innerException) : base(
            message,
            innerException)
        {
            ResponseContent = responseContent;
        }
    }
}