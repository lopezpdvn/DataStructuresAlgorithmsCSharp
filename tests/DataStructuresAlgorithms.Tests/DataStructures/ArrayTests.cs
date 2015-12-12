using System;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Array;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class SortedArrayTests
    {
        [Fact]
        public void SortedArrayTest0()
        {
            var a0 = new int[] { 1, 2, 3 };
            //Array.BinarySearch()
            var arrLength = 5;
            var arr = new SortedArrayInt(arrLength);
            foreach(var item in arr)
            {
                Assert.True(item == default(int));
            }
            Assert.Throws<IndexOutOfRangeException>(() => arr[arrLength]);
            // Indexer is read only
            //arr[0] = default(int);

            Assert.True(arr.Length == 0);
            arr.Delete(5);
            arr.Delete(0);
            Assert.True(arr.Length == 0);
            Assert.True(arr.Length == 0);
        }
    }
}
