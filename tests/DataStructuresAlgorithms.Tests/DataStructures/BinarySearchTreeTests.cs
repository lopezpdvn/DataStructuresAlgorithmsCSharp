using Xunit;
using DataStructuresAlgorithms.DataStructures.Tree.BinaryTree.BinarySearchTree;

namespace DataStructuresAlgorithms.Tests.DataStructures.Tree.BinarySearchTree
{
    public class BinarySearchTreeIntFixture
    {
        public int[] keys;
        public int[] sortedKeys;
        public NodeInt[] nodes;
        public NodeInt[] nonExistentNodes;
        public int[] nonExistentKeys;
        public BinarySearchTreeInt bstInt;

        public BinarySearchTreeIntFixture()
        {
            keys = new int[]{ 99, -9, 0, -99, -999, 999, 9 };
            nonExistentKeys = new int[]{-500, 500, 50, -5, 5};
            sortedKeys = new int[keys.Length];
            keys.CopyTo(sortedKeys, 0);
            System.Array.Sort(sortedKeys);
            nodes = new NodeInt[keys.Length];
            nonExistentNodes = new NodeInt[nonExistentKeys.Length];
            bstInt = new BinarySearchTreeInt();
            var j = 0;
            foreach(var i in keys)
            {
                nodes[j] = new NodeInt(i);
                bstInt.Insert(nodes[j++]);
            }
            j = 0;
            foreach(var i in nonExistentKeys)
            {
                nonExistentNodes[j++] = new NodeInt(i);
            }
        }
    }

    [CollectionDefinition("BST Collection")]
    public class BSTCollection :
        ICollectionFixture<BinarySearchTreeIntFixture> { }

    [Collection("BST Collection")]
    public class BinarySearchTreeIntTests
    {
        BinarySearchTreeIntFixture fixture;

        public BinarySearchTreeIntTests(BinarySearchTreeIntFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void InsertTest0()
        {
            var j = 0;
            foreach(var i in fixture.bstInt.IODFTraversal())
            {
                Assert.True(i.Value == fixture.sortedKeys[j++]);
            }
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

            //Assert.True(largest1 == largest);
            Assert.True(largest1 >= largest);
            Assert.True(largest1 <= largest);
        }

        [Fact]
        public void FindTest0()
        {
            foreach(var target in fixture.nodes)
            {
                Assert.True(target == fixture.bstInt.Find(target));
            }
            foreach(var nonExistentNode in fixture.nonExistentNodes)
            {
                Assert.True(null == fixture.bstInt.Find(nonExistentNode));
            }
        }
    }
}