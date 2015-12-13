using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.Array
{
    public class SortedArrayInt : IEnumerable<int>
    {
        private int[] arr;
        public int Length { get; private set; }
        public int Count { get; private set; } = 0;

        public SortedArrayInt(int length)
        {
            Length = length;
            arr = new int[Length];
        }

        public int this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return arr[index];
                }
            }
        }

        public bool Delete(int key)
        {
            var index = BinarySearchIterative(key);
            return index > 0;
        }

        public IEnumerator<int> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public void Insert(int item)
        {
            try
            {
                var i = Count - 1;
                for (; i >= 0 && item < arr[i]; i--)
                {
                    arr[i + 1] = arr[i];
                }
                arr[i + 1] = item;
                Count++;
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Array is full");
            }

        }

        public int BinarySearchIterative(int key)
        {
            return -1;
        }

        public int BinarySearchRecursive(int key)
        {
            throw new NotImplementedException();
        }
    }
}
