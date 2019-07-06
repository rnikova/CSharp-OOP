using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public static class Validator
    {
        public static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                throw new Exception("Name cannot be empty");
            }
        }

        public static void ValidateMoney(decimal money)
        {
            if (money < 0)
            {
                throw new Exception("Money cannot be negative");
            }
        }
    }
}
