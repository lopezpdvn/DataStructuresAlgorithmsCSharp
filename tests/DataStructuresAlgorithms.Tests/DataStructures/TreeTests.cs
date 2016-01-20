using System;
using System.Collections;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Tree.BinaryTree;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures.Tree.BinaryTree
{
    public class BinaryTreeTests
    {
        BinaryTree<int> travTree0;
        BinaryTree<char> treeLetters;
        IDictionary treeLetter = new Hashtable();
        public BinaryTreeTests()
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

            var _J = new Node<char>('J');
            var _I = new Node<char>(_J, null, 'I');
            var _H = new Node<char>(null, _I, 'H');
            var _D = new Node<char>(_H, null, 'D');
            var _M = new Node<char>(null, null, 'M');
            var _L = new Node<char>(null, _M, 'L');
            var _K = new Node<char>(_L, null, 'K');
            var _E = new Node<char>(_K, null, 'E');
            var _B = new Node<char>(_D, _E, 'B');
            var _F = new Node<char>(null, null, 'F');
            var _S = new Node<char>(null, null, 'S');
            var _R = new Node<char>(_S, null, 'R');
            var _N = new Node<char>(_R, null, 'N');
            var _Q = new Node<char>(null, null, 'Q');
            var _P = new Node<char>(null, _Q, 'P');
            var _O = new Node<char>(null, _P, 'O');
            var _G = new Node<char>(_N, _O, 'G');
            var _C = new Node<char>(_F, _G, 'C');
            var _A = new Node<char>(_B, _C, 'A');
            treeLetters = new BinaryTree<char>(_A);
            treeLetter["tree"] = treeLetters;
            treeLetter["bf_traversal_char_array"] =
                "ABCDEFGHKNOILRPJMSQ".ToCharArray();
        }

        [Fact]
        public void PostOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nPostOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            var orderedLetters = "JIHDMLKEBFSRNQPOGCA".ToCharArray();
            int i = 0;
            foreach(var nodeVal in BinaryTree<int>.PostOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PostOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>.PostOrderTraversalRecursiveIterator(treeLetters.Root))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>.PostOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void PreOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nPreOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 100, 50, 25, 75, 150, 125, 110, 175 };
            var orderedLetters = "ABDHIJEKLMCFGNRSOPQ".ToCharArray();

            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>.PreOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>.PreOrderTraversalRecursiveIterator(treeLetters.Root))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>.PreOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void InOrderTraversalRecursiveIteratorTest()
        {
            Console.WriteLine("\nInOrderTraversalRecursionTest1");
            var orderedVals = new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };
            var orderedLetters = "HJIDBLMKEAFCSRNGOPQ".ToCharArray();

            int i = 0;
            foreach (var nodeVal in BinaryTree<int>.InOrderTraversalRecursiveIterator(travTree0.Root))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach(var nodeVal in BinaryTree<int>.InOrderTraversalRecursiveIterator(null))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>.InOrderTraversalRecursiveIterator(treeLetters.Root))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>.InOrderTraversalRecursiveIterator(null))
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
            var orderedLetters = "ABDHIJEKLMCFGNRSOPQ".ToCharArray();

            int i = 0;
            foreach (var nodeVal in BinaryTree<int>
                .PreOrderTraversalIterativeIterator(travTree0.Root,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>
                .PreOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>
                .PreOrderTraversalIterativeIterator(treeLetters.Root,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>
                .PreOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void InOrderTraversalIterativeIteratorTest()
        {
            Console.WriteLine("\nInOrderTraversalIterativeIteratorTest");
            var orderedVals = new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };
            var orderedLetters = "HJIDBLMKEAFCSRNGOPQ".ToCharArray();

            int i = 0;
            foreach (var nodeVal in BinaryTree<int>
                .InOrderTraversalIterativeIterator(travTree0.Root,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>
                .InOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>
                .InOrderTraversalIterativeIterator(treeLetters.Root,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>
                .InOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void PostOrderTraversalIterativeIteratorTest()
        {
            Console.WriteLine("\nPostOrderTraversalIterativeIteratorTest");
            var orderedVals = new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            var orderedLetters = "JIHDMLKEBFSRNQPOGCA".ToCharArray();

            int i = 0;
            foreach (var nodeVal in BinaryTree<int>
                .PostOrderTraversalIterativeIterator(travTree0.Root,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(nodeVal.Value == orderedVals[i++]);
            }
            foreach (var nodeVal in BinaryTree<int>
                .PostOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<int>>()))
            {
                Assert.True(false);
            }

            i = 0;
            foreach (var nodeLetter in BinaryTree<char>
                .PostOrderTraversalIterativeIterator(treeLetters.Root,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
            foreach (var nodeLetter in BinaryTree<char>
                .PostOrderTraversalIterativeIterator(null,
                new StackSinglyLinkedList<INode<char>>()))
            {
                Assert.True(false);
            }
        }

        [Fact]
        public void BreadthFirstTraversalQueue()
        {
            foreach (var nodeLetter in BinaryTree<char>
                .BreadthFirstTraversalQueue(null,
                new QueueSinglyLinkedList<INode<char>>()))
            {
                Assert.True(false);
            }

            var treeLetters = (BinaryTree<char>)treeLetter["tree"];
            var orderedLetters = (char[])treeLetter["bf_traversal_char_array"];
            int i = 0;
            foreach (var nodeLetter in BinaryTree<char>
                .BreadthFirstTraversalQueue(treeLetters.Root,
                new QueueSinglyLinkedList<INode<char>>()))
            {
                Assert.True(nodeLetter.Value == orderedLetters[i++]);
            }
        }

        [Fact]
        public void NodeIteratorTest()
        {
            var B = new Node<char>('B');
            var C = new Node<char>('C');
            var orderedNodes = new Node<char>[] { B, C };
            var tree = new BinaryTree<char>(
                new Node<char>(B, C, 'A'));
            int i = 0;
            foreach(var node in tree.Root.EnumerateLR())
            {
                Assert.True(node == orderedNodes[i++]);
            }
        }
    }
}
