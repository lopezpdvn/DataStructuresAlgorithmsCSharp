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

        public int Delete(int key)
        {
            var index = BinarySearchIterative(key);
            if(index >= 0)
            {
                for (var i = index; i < Count - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                Count--;
            }
            return index;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(var i = 0; i < Count; i++)
            {
                yield return arr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Insert(int item)
        {
            try
            {
                var i = Count;
                for (; i > 0 && item < arr[i - 1]; i--)
                {
                    arr[i] = arr[i - 1];
                }
                arr[i] = item;
                Count++;
            }
            catch(IndexOutOfRangeException)
            {
                throw new InvalidOperationException("Array is full");
            }
        }
        
        public int BinarySearchIterative(int key)
        {
            return BinarySearchIterative(arr, key, 0, Count - 1);
        }

        public static int BinarySearchIterative(int[] arr, int key, int min,
            int max)
        {
            int mid;
            while(min < max)
            {
                mid = min + ((max - min) / 2);
                if(arr[mid] < key)
                {
                    min = mid + 1;
                }
                else
                {
                    max = mid;
                }
            }
            
            if((max == min) && (arr[min] == key))
            {
                return min;
            }
            else
            {
                return -1;
            }
        }

        public int BinarySearchRecursive(int key)
        {
            return BinarySearchRecursive(arr, key, 0, Count - 1);
        }
        
        public static int BinarySearchRecursive(int[] arr, int key, int min,
            int max)
        {
            if(max < min)
            {
                return -1;
            }

            int mid = min + ((max - min) / 2);

            if(arr[mid] > key)
            {
                return BinarySearchRecursive(arr, key, min, mid - 1);
            }
            else if(arr[mid] < key)
            {
                return BinarySearchRecursive(arr, key, mid + 1, max);
            }
            else
            {
                return mid;
            }
        }
    }
}
