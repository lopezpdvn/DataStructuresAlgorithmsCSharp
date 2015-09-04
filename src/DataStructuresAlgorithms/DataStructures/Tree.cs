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

        public static IEnumerable<T> PreOrderTraversalIterativeIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                Node<T> curr = stack.Pop();
                yield return curr.Value;
                if (curr.Right != null)
                {
                    stack.Push(curr.Right);
                }
                if (curr.Left != null)
                {
                    stack.Push(curr.Left);
                }
            }
        }

        public static IEnumerable<T> PostOrderTraversalIterativeIterator(Node<T> node)
        {
            if (node == null) yield break;

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
                        yield return peekNode.Value;
                        lastNodeVisited = stack.Pop();
                        node = null;
                    }
                }
            }
        }

        public static IEnumerable<T> InOrderTraversalIterativeIterator(Node<T> tree)
        {
            if (tree == null) yield break;

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
                    yield return curr.Value;
                    curr = curr.Right;
                }
            }
        }

        public static IEnumerable<T> PostOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            if (tree.Left != null)
                foreach (var val in PostOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PostOrderTraversalRecursiveIterator(tree.Right))
                    yield return val;
            yield return tree.Value;
        }

        public static IEnumerable<T> PreOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            yield return tree.Value;
            if (tree.Left != null)
                foreach (var val in PreOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PreOrderTraversalRecursiveIterator(tree.Right))
                    yield return val;
        }

        public static IEnumerable<T> InOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;
            if (tree.Left != null)
                foreach (var val in InOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            yield return tree.Value;
            if (tree.Right != null)
                foreach (var val in InOrderTraversalRecursiveIterator(tree.Right))
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
