using CollectionHierarchy.Contracts;
using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private IAddCollection addCollection;
        private IAddRemoveCollection addRemoveCollection;
        private IMyList myList;
        private StringBuilder resultingOutput;

        public Engine()
        {
            this.addCollection = new AddCollection();
            this.addRemoveCollection = new AddRemoveCollection();
            this.myList = new MyList();
            this.resultingOutput = new StringBuilder();
        }

        public void Run()
        {
            string[] items = Console.ReadLine().Split();

            AddInAllCollections(items, addCollection);
            AddInAllCollections(items, addRemoveCollection);
            AddInAllCollections(items, myList);

            int removeCount = int.Parse(Console.ReadLine());

            RemoveElements(removeCount, addRemoveCollection);
            RemoveElements(removeCount, myList);

            Console.WriteLine(this.resultingOutput.ToString().TrimEnd());
        }

        private void RemoveElements(int removeCount, IAddRemoveCollection collection)
        {
            for (int i = removeCount; i > 0; i--)
            {
                var removedElement = collection.Remove();
                resultingOutput.Append($"{removedElement} ");
            }

            resultingOutput
                .Remove(this.resultingOutput.Length - 1, 1)
                .AppendLine();
        }

        private void AddInAllCollections(string[] items, IAddCollection collection)
        {
            foreach (var item in items)
            {
                var index = collection.Add(item);
                resultingOutput.Append($"{index} ");
            }

            resultingOutput
                .Remove(resultingOutput.Length - 1, 1)
                .AppendLine();
        }
    }
}
