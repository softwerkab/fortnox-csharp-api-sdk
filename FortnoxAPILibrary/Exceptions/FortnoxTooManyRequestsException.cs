using System;

namespace FortnoxAPILibrary.Exceptions
{
    public class FortnoxTooManyRequestsException : Exception
    {
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
