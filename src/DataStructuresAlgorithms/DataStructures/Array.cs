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

        public bool Delete(int v)
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

        public void Insert(int i)
        {
            throw new NotImplementedException();
        }

        public int BinarySearchIterative(int v)
        {
            throw new NotImplementedException();
        }

        public int BinarySearchRecursive(int v)
        {
            throw new NotImplementedException();
        }
    }
}
