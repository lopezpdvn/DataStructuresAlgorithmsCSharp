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
            int jOut = arr.Length - 1, jIn;
            bool swapped;
            do
            {
                swapped = false;
                for (jIn = 0; jIn < jOut; jIn++)
                    if (arr[jIn] > arr[jIn + 1])
                    {
                        Swap(ref arr[jIn], ref arr[jIn + 1]);
                        swapped = true;
                    }
                jOut--;
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
            int jOut, jIn, min;
            for(jOut = 0; jOut < arr.Length - 1; jOut++)
            {
                min = jOut;
                for(jIn = jOut + 1; jIn < arr.Length; jIn++)
                {
                    if(arr[jIn] < arr[min])
                    {
                        min = jIn;
                    }
                }
                // Invariant: arr[min] smallest of arr[jOut:]
                Swap(ref arr[jOut], ref arr[min]);
                // Invariant: arr[:jOut] in final position
            }
        }
    }
}
