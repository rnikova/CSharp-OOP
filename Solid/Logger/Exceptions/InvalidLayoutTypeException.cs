using System;

namespace Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string exc_message = "Invalid Layout Type!";

        public InvalidLayoutTypeException()
            : base(exc_message)
        {

        }

        public InvalidLayoutTypeException(string message) 
            : base(message)
        {
        }
    }
}
