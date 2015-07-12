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
            Console.WriteLine("Should print 100, 50, 25, 75, 150, 125, 110, and 175");
            BinaryTree<int>.PreOrderTraversalNoRecursion(travTree0.Root);
            Assert.True(true);
        }

        [Fact]
        public void InOrderTraversalNoRecursionTest()
        {
            Console.WriteLine("Should print 25, 50, 75, 100, 110, 125, 150, 175");
            BinaryTree<int>.InOrderTraversalNoRecursion(travTree0.Root);
            Assert.True(true);
        }
    }
}
