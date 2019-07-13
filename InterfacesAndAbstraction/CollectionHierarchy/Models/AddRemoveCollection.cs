using CollectionHierarchy.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }

        public override int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public virtual string Remove()
        {

            var lastItem = this.collection.Last();
            this.collection.Remove(lastItem);

            return lastItem;
        }
    }
}
