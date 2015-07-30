﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class BinaryTree<T>
    {
        private Node<T> root;
        public Node<T> Root
        {
            get
            {
                return root;
            }
        }

        public BinaryTree(Node<T> root)
        {
            this.root = root;
        }

        public BinaryTree() : this(null) { }

        public int Height
        {
            get
            {
                return ComputeHeight(this.root);
            }
        }

        public static int ComputeHeight(Node<T> tree)
        {
            if (tree == null)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(ComputeHeight(tree.Left),
                    ComputeHeight(tree.Right));
            }
        }

        public static void PreOrderTraversalNoRecursion(Node<T> tree)
        {
            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            stack.Push(tree);
            while(stack.Count > 0)
            {
                Node<T> curr = stack.Pop();
                Console.Write("{0}, ", curr);
                if(curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
                if(curr.Left != null)
                {
                    stack.Push(curr.Left);
                }
            }
            Console.WriteLine();
        }

        internal static void PostOrderTraversalNoRecursion(Node<T> node)
        {
            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            Node<T> lastNodeVisited = null;
            Node<T> curr = node;
            Node<T> peekNode = null;
            while(stack.Count > 0 || node != null)
            {
                if(node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    peekNode = stack.FirstNode.Value;
                    if(peekNode.Right != null && lastNodeVisited != peekNode.Right)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        Console.Write("{0}, ", peekNode);
                        lastNodeVisited = stack.Pop();
                        node = null;
                    }
                }
            }
            Console.WriteLine();
        }

        internal static void InOrderTraversalNoRecursion(Node<T> tree)
        {
            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            Node<T> curr = tree;
            while (stack.Count > 0 || curr != null)
            {
                if (curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    curr = stack.Pop();
                    Console.Write("{0}, ", curr);
                    curr = curr.Right;
                }
            }
            Console.WriteLine();
        }

        internal static void PostOrderTraversalRecursion(Node<int> tree)
        {
            if (tree == null) return;
            PostOrderTraversalRecursion(tree.Left);
            PostOrderTraversalRecursion(tree.Right);
            Console.Write("{0}, ", tree);
        }
    }

    public class Node<T>
    {
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public T Value { get; set; }

        public Node(Node<T> left, Node<T> right, T value)
        {
            Left = left;
            Right = right;
            Value = value;
        }

        public Node(T value) : this(null, null, value) { }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

    public static class Program
    {
        public static void TestHeight()
        {
            // Create tree
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

            Console.WriteLine("Tree height: " + tree.Height);

            BinaryTree<int> tree1 = new BinaryTree<int>(new Node<int>(new Node<int>(1), null, 0));
            Console.WriteLine("Tree height: " + tree1.Height);
        }
    }
}