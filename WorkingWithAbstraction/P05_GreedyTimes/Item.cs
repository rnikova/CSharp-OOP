using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Item
    {
        public Item(string name, long amount)
        {
            this.ItemName = name;
            this.Amount = amount;
        }

        public string ItemName { get; set; }

        public long Amount { get; set; }
    }
}
