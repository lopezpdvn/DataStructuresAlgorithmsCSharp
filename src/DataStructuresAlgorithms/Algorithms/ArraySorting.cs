using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructuresAlgorithms.Algorithms
{
    public class ArraySorting
    {
        public static void BubbleSort(int[] arr)
        {
            int o = arr.Length - 1, i;
            bool swapped;
            do
            {
                swapped = false;
                for (i = 0; i < o; i++)
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                        swapped = true;
                    }
                o--;
            }
            while (swapped);
        }

        public static void Swap<V>(ref V i, ref V j)
        {
            V tmp = i;
            i = j;
            j = tmp;
        }

        public static void SelectionSort(int[] arr)
        {
            int o, i, min;
            for(o = 0; o < arr.Length - 1; o++)
            {
                min = o;
                for(i = o + 1; i < arr.Length; i++)
                {
                    if(arr[i] < arr[min])
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
            int i, o;
            for(o = 1; o < arr.Length; o++)
            {
                for(i = o; i > 0 && arr[i] < arr[i - 1]; i--)
                {
                    Swap(ref arr[i], ref arr[i - 1]);
                }
                // Invariant: arr[:o] is sorted
            }
        }
    }
}
