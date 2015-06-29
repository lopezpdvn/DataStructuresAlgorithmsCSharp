using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.AssociativeArray
{
    internal interface IAssociativeArray<TKey, TValue>
    {
        void Add(TKey key, TValue value);
        void Reassign(TKey key, TValue value);
        void Remove(TKey key);
        TValue Lookup(TKey key);
    }
}
