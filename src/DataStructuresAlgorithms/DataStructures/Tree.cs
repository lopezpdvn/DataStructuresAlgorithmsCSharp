using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataStructures.Tree
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; private set; }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public BinaryTree() : this(null) { }

        public int Height
        {
            get
            {
                return ComputeHeight(Root);
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

        public static void PostOrderTraversalNoRecursion(Node<T> node)
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

        public static void InOrderTraversalNoRecursion(Node<T> tree)
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

        public static IEnumerable<int> PostOrderTraversalIterator(Node<int> tree)
        {
            if (tree.Left != null)
                foreach (var val in PostOrderTraversalIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PostOrderTraversalIterator(tree.Right))
                    yield return val;
            yield return tree.Value;
        }

        public static IEnumerable<int> PreOrderTraversalIterator(Node<int> tree)
        {
            yield return tree.Value;
            if (tree.Left != null)
                foreach (var val in PreOrderTraversalIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PreOrderTraversalIterator(tree.Right))
                    yield return val;
        }

        public static IEnumerable<int> InOrderTraversalIterator(Node<int> tree)
        {
            if (tree.Left != null)
                foreach (var val in InOrderTraversalIterator(tree.Left))
                    yield return val;
            yield return tree.Value;
            if (tree.Right != null)
                foreach (var val in InOrderTraversalIterator(tree.Right))
                    yield return val;
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
}
