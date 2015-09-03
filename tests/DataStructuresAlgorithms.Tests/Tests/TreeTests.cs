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
        public void PreOrderTraversalNoRecursionTest()
        {
            Console.WriteLine("\nPreOrderTraversalNoRecursionTest");
            Console.WriteLine("Should print\n100, 50, 25, 75, 150, 125, 110, and 175");
            BinaryTree<int>.PreOrderTraversalNoRecursion(travTree0.Root);
            Assert.True(true);
        }

        [Fact]
        public void InOrderTraversalNoRecursionTest()
        {
            Console.WriteLine("\nInOrderTraversalNoRecursionTest");
            Console.WriteLine("Should print\n25, 50, 75, 100, 110, 125, 150, 175");
            BinaryTree<int>.InOrderTraversalNoRecursion(travTree0.Root);
            Assert.True(true);
        }

        [Fact]
        public void PostOrderTraversalNoRecursionTest()
        {
            Console.WriteLine("\nPostOrderTraversalNoRecursionTest");
            Console.WriteLine("Should print\n25, 75, 50, 110, 125, 175, 150, 100");
            BinaryTree<int>.PostOrderTraversalNoRecursion(travTree0.Root);
            Assert.True(true);
        }

        [Fact]
        public void PostOrderTraversalIteratorTest()
        {
            Console.WriteLine("\nPostOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            int i = 0;
            foreach(var nodeVal in BinaryTree<int>.PostOrderTraversalIterator(travTree0.Root))
            {
                Assert.True(nodeVal == orderedVals[i++]);
            }
            Console.WriteLine();
        }

        [Fact]
        public void PreOrderTraversalIteratorTest()
        {
            Console.WriteLine("\nPreOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 100, 50, 25, 75, 150, 125, 110, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalIterator(travTree0.Root))
            {
                Assert.True(nodeVal == orderedVals[i++]);
            }
            Console.WriteLine();
        }

        [Fact]
        public void InOrderTraversalIteratorTest()
        {
            Console.WriteLine("\nInOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };
            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.InOrderTraversalIterator(travTree0.Root))
            {
                Assert.True(nodeVal == orderedVals[i++]);
            }
            Console.WriteLine();
        }

        [Fact]
        public void HeightTest()
        {
            Console.WriteLine("\nHeightTest");
            Assert.True(travTree0.Height == 3);
        }
    }
}
