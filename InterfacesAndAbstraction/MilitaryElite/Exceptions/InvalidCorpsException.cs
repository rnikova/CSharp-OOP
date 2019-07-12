using System;

namespace MilitaryElite.Exeptions
{
    public class InvalidCorpsException : Exception
    {
        private const string INVALID_CORPS_MESSAGE = "Invalid message!";

        public InvalidCorpsException()
            : base(INVALID_CORPS_MESSAGE)
        {

        }

        public InvalidCorpsException(string message)
            : base(message)
        {

        }
    }
}
