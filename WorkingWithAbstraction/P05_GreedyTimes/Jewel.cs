using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05_GreedyTimes
{
    public class Jewel
    {
        public Jewel(string name)
        {
            this.Name = name;
            this.Jewels = new List<Item>();
        }

        public string Name { get; set; }

        public List<Item> Jewels { get; set; }

        public long Sum()
        {
            return this.Jewels.Sum(x => x.Amount);
        }
    }
}
