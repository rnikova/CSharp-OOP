using System.Collections.Generic;

namespace CollectionHierarchy.Contracts
{
    public interface IAddRemoveCollection : IAddCollection
    {
        string Remove();
    }
}
