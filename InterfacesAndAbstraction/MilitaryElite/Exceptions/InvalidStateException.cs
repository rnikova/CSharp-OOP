using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidStateException : Exception
    {
        private const string INVALID_STATE_MESSAGE = "Invalid State!";

        public InvalidStateException()
        {

        }
        public InvalidStateException(string message)
            : base(message)
        {
        }
    }
}
