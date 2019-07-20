using System;

namespace Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string exc_message = "Invalid DateTime Format!";

        public InvalidDateFormatException()
            : base(exc_message)
        {
        }

        public InvalidDateFormatException(string message) 
            : base(message)
        {
        }

        public InvalidDateFormatException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}
