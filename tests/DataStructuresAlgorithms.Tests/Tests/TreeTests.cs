using DataStructures.Tree;
using Xunit;
using System;

namespace DataStructures.Tests
{
    public class TreeTests
    {
        BinaryTree<int> travTree0;
        public TreeTests()
        {
            /*
                100
               /  \
              /    \
             /      \
            50      150
           / \      /  \
          25  75   125  175
                    /
                  110
            */
            travTree0 = new BinaryTree<int>(new Node<int>(

                new Node<int>(
                    new Node<int>(25), new Node<int>(75), 50),

                new Node<int>(
                    new Node<int>(
                        new Node<int>(110), null, 125),
                    new Node<int>(null, null, 175)

                 , 150)

                 , 100));
        }

        [Fact]
        public void PostOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nPostOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            int i = 0;
            foreach(var nodeVal in BinaryTree<int>.PostOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PostOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void PreOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nPreOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 100, 50, 25, 75, 150, 125, 110, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void InOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nInOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.InOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach(var nodeVal in BinaryTree<int>.InOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void HeightTest()
        {
            Console.WriteLine("\nHeightTest");
            Assert.True(travTree0.Height == 3);

            var nodeI = new Node<char>(null, null, 'I');
            var nodeF = new Node<char>(null, null, 'F');
            var nodeG = new Node<char>(null, null, 'G');
            var nodeH = new Node<char>(null, nodeI, 'H');
            var nodeD = new Node<char>(nodeF, nodeG, 'D');
            var nodeE = new Node<char>(null, nodeH, 'E');
            var nodeC = new Node<char>(nodeD, nodeE, 'C');
            var nodeB = new Node<char>(null, null, 'B');
            var nodeA = new Node<char>(nodeB, nodeC, 'A');
            BinaryTree<char> tree = new BinaryTree<char>(nodeA);
            Assert.True(tree.Height == 4);

            BinaryTree<int> tree1 = new BinaryTree<int>(new Node<int>(new Node<int>(1), null, 0));
            Assert.True(tree1.Height == 1);

            var emptyTree = new BinaryTree<int>();
            Assert.True(emptyTree.Height == -1);

            var oneNodeTree = new BinaryTree<int>(new Node<int>(15));
            Assert.True(oneNodeTree.Height == 0);
        }

        [Fact]
        public void PreOrderTraversalIterativeIteratorTest()
        {
            Console.WriteLine("\nPreOrderTraversalIterativeIteratorTest");
            var orderedVals = new int[] { 100, 50, 25, 75, 150, 125, 110, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalIterativeIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalIterativeIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void InOrderTraversalIterativeIteratorTest()
        {
            Console.WriteLine("\nInOrderTraversalIterativeIteratorTest");
            var orderedVals = new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.InOrderTraversalIterativeIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.InOrderTraversalIterativeIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void PostOrderTraversalIterativeIteratorTest()
        {
            Console.WriteLine("\nPostOrderTraversalIterativeIteratorTest");
            var orderedVals = new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.PostOrderTraversalIterativeIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PostOrderTraversalIterativeIterator(null))
            {
                Assert.True(false);
            }
        }
    }
}
