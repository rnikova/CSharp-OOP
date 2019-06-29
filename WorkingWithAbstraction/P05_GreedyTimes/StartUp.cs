using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{
    public class StartUp
    {
        static List<Jewel> bag;
        static Item item;
        static int index = -1;
        static string type = string.Empty;

        public static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] quantityPair = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            bag = new List<Jewel>();
            bag.Add(new Jewel("Gold"));
            bag.Add(new Jewel("Gem"));
            bag.Add(new Jewel("Cash"));


            for (int i = 0; i < quantityPair.Length; i += 2)
            {
                string typeOfItem = quantityPair[i];
                long quantityItem = long.Parse(quantityPair[i + 1]);

                CheckType(typeOfItem);

                if (type == "")
                {
                    continue;
                }

                if (capacity < bag.Sum(x => x.Sum()) + quantityItem)
                {
                    continue;
                }

                item = new Item(typeOfItem, quantityItem);

                bag[index] = CheckContainsJewel(type, typeOfItem, quantityItem);
            }

            foreach (var jewel in bag.Where(x => x.Jewels.Count > 0))
            {
                Console.WriteLine($"<{jewel.Name}> ${jewel.Jewels.Sum(x => x.Amount)}");

                foreach (var currentItem in jewel.Jewels.OrderByDescending(y => y.ItemName).ThenBy(y => y.Amount).Where(x => x.Amount > 0))
                {
                    Console.WriteLine($"##{currentItem.ItemName} - {currentItem.Amount}");
                }
            }
        }

        private static void CheckType(string typeOfItem)
        {
            if (typeOfItem.Length == 3)
            {
                type = "Cash";
                index = 2;
            }
            else if (typeOfItem.ToLower().EndsWith("gem"))
            {
                type = "Gem";
                index = 1;
            }
            else if (typeOfItem.ToLower() == "gold")
            {
                type = "Gold";
                index = 0;
            }
        }

        private static Jewel CheckContainsJewel(string type, string typeOfItem, long quantityItem)
        {
            Jewel currentJewel = bag.FirstOrDefault(x => x.Name == type);

            Item currentItem = currentJewel.Jewels.FirstOrDefault(x => x.ItemName == typeOfItem);

            if (currentItem == null)
            {
                AddJewels(currentJewel, quantityItem);
            }
            else
            {
                IncreaceJewels(currentItem, quantityItem, currentJewel);
            }

            return currentJewel;
        }

        private static void IncreaceJewels(Item currentItem, long quantityItem, Jewel currentJewel)
        {
            if (currentJewel.Name == "Gold" &&
                    bag[0].Sum() + quantityItem >= bag[1].Sum())
            {
                currentItem.Amount += quantityItem;
            }
            else if (currentJewel.Name == "Gem" &&
                bag[1].Sum() + quantityItem >= bag[2].Sum() &&
                bag[1].Sum() + quantityItem < bag[0].Sum())
            {
                currentItem.Amount += quantityItem;
            }
            else if (currentJewel.Name == "Cash" &&
                bag[2].Sum() + quantityItem < bag[1].Sum())
            {
                currentItem.Amount += quantityItem;
            }
        }

        private static void AddJewels(Jewel currentJewel, long quantityItem)
        {
            if (currentJewel.Name == "Gold" &&
                    bag[0].Sum() + quantityItem >= bag[1].Sum())
            {
                currentJewel.Jewels.Add(item);
            }
            else if (currentJewel.Name == "Gem" &&
                bag[1].Sum() + quantityItem >= bag[2].Sum() &&
                bag[2].Sum() + quantityItem < bag[0].Sum())
            {
                currentJewel.Jewels.Add(item);
            }
            else if (currentJewel.Name == "Cash" &&
                bag[2].Sum() + quantityItem <= bag[1].Sum())
            {
                currentJewel.Jewels.Add(item);
            }
        }
    }
}