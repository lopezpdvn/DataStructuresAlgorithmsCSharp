using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructuresAlgorithms.DataStructures.Array
{
    public class SortedArrayInt : IEnumerable<int>
    {
        protected int[] arr;
        public int Length { get; protected set; }
        public int Count { get; protected set; } = 0;

        public SortedArrayInt(int length = 64)
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

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

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

            return (max == min) && (arr[min] == key) ? min : -1;
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

        // Greater elements bubble up to the top end of the array.
        public static void BubbleSort(int[] arr)
        {
            int o, i;
            bool swapped;
            for (swapped = true, o = arr.Length - 1; swapped && o > 0; o--)
            {
                for (i = 0, swapped = false; i < o; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                }
                // Invariant: arr[o:] in final position
            }
        }

        public static void MergeSort(int[] arr)
        {
            throw new NotImplementedException();
        }

        public static void Merge(int[] arrA, int sizeA,
            int[] arrB, int sizeB, int[] arrC)
        {
            int iA = 0, iB = 0, iC = 0;
            while(iA < sizeA && iB < sizeB)
            {
                arrC[iC++] = arrA[iA] < arrB[iB] ? arrA[iA++] : arrB[iB++];
            }
            while(iA < sizeA)
            {
                arrC[iC++] = arrA[iA++];
            }
            while(iB < sizeB)
            {
                arrC[iC++] = arrB[iB++];
            }
        }

        public static void Swap<V>(ref V i, ref V j)
        {
            V tmp = i;
            i = j;
            j = tmp;
        }

        public static void SelectionSort(int[] arr)
        {
            for (int min = 0, o = 0; o < arr.Length - 1; min = ++o)
            {
                for (int i = o + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[min])
                    {
                        min = i;
                    }
                }
                // Invariant: arr[min] smallest of arr[o:]
                Swap(ref arr[o], ref arr[min]);
                // Invariant: arr[:o] in final position
            }
        }

        public static void InsertionSort(int[] arr)
        {
            for (int o = 1; o < arr.Length; o++)
            {
                for (int i = o; i > 0 && arr[i] < arr[i - 1]; i--)
                {
                    Swap(ref arr[i], ref arr[i - 1]);
                }
                // Invariant: arr[:o] is sorted
            }
        }
    }
}
