using System;

namespace Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string exc_message = "Invalid Appender Type!";

        public InvalidAppenderTypeException()
            : base(exc_message)
        {
        }

        public InvalidAppenderTypeException(string message)
            : base(message)
        {
        }
    }
}
