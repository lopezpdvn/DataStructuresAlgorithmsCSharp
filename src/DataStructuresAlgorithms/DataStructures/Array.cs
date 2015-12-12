using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.Array
{
    public class SortedArrayInt : IEnumerable<int>
    {
        private int[] arr;
        public int Length { get; private set; }

        public SortedArrayInt(int length)
        {
            Length = length;
            arr = new int[Length];
        }

        public int this[int index]
        {
            get { return arr[index]; }
        }

        public void Delete(int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
