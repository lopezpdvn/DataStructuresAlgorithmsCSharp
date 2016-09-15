using Xunit;
using DataStructuresAlgorithms.DataStructures.Tree.BinaryTree.BinarySearchTree;

namespace DataStructuresAlgorithms.Tests.DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTreeIntTests
    {
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