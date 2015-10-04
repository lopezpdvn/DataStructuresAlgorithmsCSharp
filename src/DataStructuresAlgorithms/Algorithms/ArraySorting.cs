using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructuresAlgorithms.Algorithms
{
    public class ArraySorting
    {
        public static void BubbleSortInt32(int[] arr)
        {
            int jOut = arr.Length - 1, jIn;
            bool swapped;
            do
            {
                swapped = false;
                for (jIn = 0; jIn < jOut; jIn++)
                    if (arr[jIn] > arr[jIn + 1])
                    {
                        SwapArrayElements(arr, jIn, jIn + 1);
                        swapped = true;
                    }
                jOut--;
            }
            while (swapped);
        }

        public static void SwapArrayElements<V>(V[] arr, int i, int j)
        {
            V tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = tmp;
        }
    }
}
