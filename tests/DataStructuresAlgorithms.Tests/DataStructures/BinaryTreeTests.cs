﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Tree;
using DataStructuresAlgorithms.DataStructures.Tree.BinaryTree;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures.Tree.BinaryTree
{
    public class BinaryTreeTraversalFixture
    {
        public IDictionary charTree = new Hashtable();
        public IDictionary intTree = new Hashtable();

        public BinaryTreeTraversalFixture()
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
            var _intTree = new BinaryTree<int>(new Node<int>(

                new Node<int>(
                    new Node<int>(25), new Node<int>(75), 50),

                new Node<int>(
                    new Node<int>(
                        new Node<int>(110), null, 125),
                    new Node<int>(null, null, 175)

                 , 150)

                 , 100));
            intTree["tree"] = _intTree;
            intTree["bft"] = new int[] { 100, 50, 150, 25, 75, 125, 175, 110 };
            intTree["dft-post"] =
                new int[] { 25, 75, 50, 110, 125, 175, 150, 100 };
            intTree["dft-pre"] =
                new int[] { 100, 50, 25, 75, 150, 125, 110, 175 };
            intTree["dft-in"] =
                new int[] { 25, 50, 75, 100, 110, 125, 150, 175 };

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
            var _charTree = new BinaryTree<char>(_A);
            charTree["tree"] = _charTree;
            charTree["bft"] = "ABCDEFGHKNOILRPJMSQ";
            charTree["dft-post"] = "JIHDMLKEBFSRNQPOGCA";
            charTree["dft-pre"] = "ABDHIJEKLMCFGNRSOPQ";
            charTree["dft-in"] = "HJIDBLMKEAFCSRNGOPQ";
        }
    }

    public abstract class BinaryTreeTraversalTests
    {
        protected BinaryTreeTraversalFixture fixture;
        protected Func<INode<char>, IEnumerable<INode<char>>>
            TraversalAlgorithmChar;
        protected Func<INode<int>, IEnumerable<INode<int>>>
            TraversalAlgorithmInt;
        protected string traversalType;

        [Fact]
        public void TraversalTest()
        {
            var traversalCharSeq = new StringBuilder();
            var traversalCharSeqCorrect =
                (string)fixture.charTree[traversalType];
            var charTree = (BinaryTree<char>) fixture.charTree["tree"];
            foreach (var node in TraversalAlgorithmChar(charTree.Root))
            {
                traversalCharSeq.Append(node.Value);
            }
            Assert.True(traversalCharSeqCorrect.SequenceEqual(
                    traversalCharSeq.ToString()));

            var traversalIntSeqCorrect = (int[])fixture.intTree[traversalType];
            var traversalIntSeq = new int[traversalIntSeqCorrect.Length];
            var intTree = (BinaryTree<int>)fixture.intTree["tree"];
            var i = 0;
            foreach(var node in TraversalAlgorithmInt(intTree.Root))
            {
                traversalIntSeq[i++] = node.Value;
            }
            Assert.True(traversalIntSeqCorrect.SequenceEqual(traversalIntSeq));
        }
    }

    [CollectionDefinition("Binary Tree Traversal Collection")]
    public class BinaryTreeTraversalCollection :
        ICollectionFixture<BinaryTreeTraversalFixture> { }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreeBreadthFirstTraversalTests
        : BinaryTreeTraversalTests
    {
        public BinaryTreeBreadthFirstTraversalTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "bft";
            TraversalAlgorithmChar = (INode<char> node)
                => BinaryTree<char>.BreadthFirstTraversalIterativeIterator(
                    node, new QueueSinglyLinkedList<INode<char>>());
            TraversalAlgorithmInt = (INode<int> node)
                => BinaryTree<int>.BreadthFirstTraversalIterativeIterator(
                    node, new QueueSinglyLinkedList<INode<int>>());
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreePostOrderTraversalRecursiveIteratorTests
        : BinaryTreeTraversalTests
    {
        public BinaryTreePostOrderTraversalRecursiveIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-post";
            TraversalAlgorithmChar =
                BinaryTree<char>.PostOrderTraversalRecursiveIterator;
            TraversalAlgorithmInt =
                BinaryTree<int>.PostOrderTraversalRecursiveIterator;
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreePreOrderTraversalRecursiveIteratorTests
    : BinaryTreeTraversalTests
    {
        public BinaryTreePreOrderTraversalRecursiveIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-pre";
            TraversalAlgorithmChar =
                BinaryTree<char>.PreOrderTraversalRecursiveIterator;
            TraversalAlgorithmInt =
                BinaryTree<int>.PreOrderTraversalRecursiveIterator;
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreeInOrderTraversalRecursiveIteratorTests
        : BinaryTreeTraversalTests
    {
        public BinaryTreeInOrderTraversalRecursiveIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-in";
            TraversalAlgorithmChar =
                BinaryTree<char>.InOrderTraversalRecursiveIterator;
            TraversalAlgorithmInt =
                BinaryTree<int>.InOrderTraversalRecursiveIterator;
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreePreOrderTraversalIterativeIteratorTests
    : BinaryTreeTraversalTests
    {
        public BinaryTreePreOrderTraversalIterativeIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-pre";
            TraversalAlgorithmChar = (INode<char> node)
                => BinaryTree<char>.PreOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<char>>());
            TraversalAlgorithmInt = (INode<int> node)
                => BinaryTree<int>.PreOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<int>>());
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreeInOrderTraversalIterativeIteratorTests
        : BinaryTreeTraversalTests
    {
        public BinaryTreeInOrderTraversalIterativeIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-in";
            TraversalAlgorithmChar = (INode<char> node)
                => BinaryTree<char>.InOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<char>>());
            TraversalAlgorithmInt = (INode<int> node)
                => BinaryTree<int>.InOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<int>>());
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreePostOrderTraversalIterativeIteratorTests
        : BinaryTreeTraversalTests
    {
        public BinaryTreePostOrderTraversalIterativeIteratorTests(
            BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-post";
            TraversalAlgorithmChar = (INode<char> node)
                => BinaryTree<char>.PostOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<char>>());
            TraversalAlgorithmInt = (INode<int> node)
                => BinaryTree<int>.PostOrderTraversalIterativeIterator(node,
                new StackSinglyLinkedList<INode<int>>());
        }
    }

    [Collection("Binary Tree Traversal Collection")]
    public class BinaryTreeMiscTests
    {
        private BinaryTreeTraversalFixture fixture;
        IDictionary treeLetter = new Hashtable();

        public BinaryTreeMiscTests(BinaryTreeTraversalFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void HeightTest()
        {
            var intTree = (BinaryTree<int>)fixture.intTree["tree"];
            Assert.True(intTree.Height == 3);

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

            BinaryTree<int> tree1 = new BinaryTree<int>(
                new Node<int>(new Node<int>(1), null, 0));
            Assert.True(tree1.Height == 1);

            var emptyTree = new BinaryTree<int>();
            Assert.True(emptyTree.Height == -1);

            var oneNodeTree = new BinaryTree<int>(new Node<int>(15));
            Assert.True(oneNodeTree.Height == 0);
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
