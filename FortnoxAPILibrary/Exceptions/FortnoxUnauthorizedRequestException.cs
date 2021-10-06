using System;

namespace FortnoxAPILibrary.Exceptions
{
    public class FortnoxUnauthorizedRequestException : Exception
    {
        public FortnoxUnauthorizedRequestException()
        {
        }

        public FortnoxUnauthorizedRequestException(string message) : base(message)
        {
        }

        public FortnoxUnauthorizedRequestException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}