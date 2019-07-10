using System.Collections.Generic;

namespace Telephony
{
    public class Smartphone : INumber, ISite
    {
        public Smartphone(List<string> numbers, List<string> addresses)
        {
            this.Numbers = new List<string>(numbers);
            this.Addresses = new List<string>(addresses);
        }

        public List<string> Addresses { get; private set; }

        public List<string> Numbers { get; private set; }
    }
}
