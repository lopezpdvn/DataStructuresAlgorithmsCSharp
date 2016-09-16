using Xunit;
using DataStructuresAlgorithms.DataStructures.Tree.BinaryTree.BinarySearchTree;

namespace DataStructuresAlgorithms.Tests.DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTreeIntTests
    {
        [Fact]
        public void MiscTest0()
        {
            int[] keys = { 99, -9, 0, -99, -999, 999, 9 };
            var bstInt = new BinarySearchTreeInt();
            foreach(var i in keys)
            {
                bstInt.Insert(new NodeInt(i));
            }
            System.Array.Sort(keys);
            System.Console.WriteLine();
            /*foreach(var i in bstInt.IODFTraversal())
            {
                System.Console.Write(i + " ");
            }*/
        }

        [Fact]
        public void NodeIntTests0()
        {
            var smallest = new NodeInt(-99);
            var small = new NodeInt(); // 0
            var large = new NodeInt(10);
            var largest = new NodeInt(999);
            var largest1 = new NodeInt(999);

            Assert.True(smallest < largest);
            Assert.False(smallest > largest);
            Assert.False(smallest == largest);
            Assert.True(smallest != largest);

            Assert.True(small < large);
            Assert.False(small > large);
            Assert.False(small == large);
            Assert.True(small != large);

            Assert.True(small == small);
            Assert.True(largest1 == largest);
            Assert.True(largest1 >= largest);
            Assert.True(largest1 <= largest);
        }
    }
}