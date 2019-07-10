namespace Telephony
{
    public static class Validator
    {
        public static bool ValidateAddress(string address)
        {
            foreach (var symbol in address)
            {
                if (char.IsDigit(symbol))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ValidateNumber(string number)
        {
            foreach (var symbol in number)
            {
                if (!char.IsDigit(symbol))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
