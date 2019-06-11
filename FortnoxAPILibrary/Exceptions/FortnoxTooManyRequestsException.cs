using System;
using System.Collections.Generic;
using System.Net;

namespace FortnoxAPILibrary.Exceptions
{
    public class FortnoxTooManyRequestsException : Exception
    {
        public HttpStatusCode Code { get; set; }

        public FortnoxTooManyRequestsException()
        {
        }

        public FortnoxTooManyRequestsException(string message) : base(message)
        {
        }

        public FortnoxTooManyRequestsException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
