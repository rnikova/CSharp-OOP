using CollectionHierarchy.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used => this.collection.Count;

        public override int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public override string Remove()
        {
            var firstItem = this.collection.First();
            this.collection.Remove(firstItem);

            return firstItem;
        }
    }
}
