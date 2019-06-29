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
            this.Name = name;//cash
            this.Jewels = new List<Item>();//usd 300, bgn 400
        }

        public string Name { get; set; }

        public List<Item> Jewels { get; set; }
    }
}
