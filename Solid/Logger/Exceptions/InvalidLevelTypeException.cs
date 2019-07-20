using System;

namespace Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string exc_message = "Invalid Level Type!";

        public InvalidLevelTypeException()
            : base(exc_message)
        {
        }

        public InvalidLevelTypeException(string message) 
            : base(message)
        {
        }
    }
}
