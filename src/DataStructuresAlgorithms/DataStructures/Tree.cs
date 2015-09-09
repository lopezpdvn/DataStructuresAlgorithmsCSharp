using System;
using System.Collections;
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

        public static IEnumerable<Node<T>> PreOrderTraversalIterativeIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            stack.Push(tree);
            while (stack.Count > 0)
            {
                Node<T> curr = stack.Pop();
                yield return curr;
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

        public static IEnumerable<Node<T>> PostOrderTraversalIterativeIterator(Node<T> node)
        {
            var stack = new AbstractDataType.StackSinglyLinkedList<Node<T>>();
            Node<T> lastNodeVisited = null;
            var curr = node;
            Node<T> peekNode = null;
            while(stack.Count > 0 || curr != null)
            {
                if(curr != null)
                {
                    stack.Push(curr);
                    curr = curr.Left;
                }
                else
                {
                    peekNode = stack.FirstNode.Value;
                    if(peekNode.Right != null && peekNode.Right != lastNodeVisited)
                    {
                        curr = peekNode.Right;
                    }
                    else
                    {
                        lastNodeVisited = stack.Pop();
                        yield return lastNodeVisited;
                        curr = null;
                    }
                }
            }
        }

        public static IEnumerable<Node<T>> InOrderTraversalIterativeIterator(Node<T> tree)
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
                    yield return curr;
                    curr = curr.Right;
                }
            }
        }

        public static IEnumerable<Node<T>> PostOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            if (tree.Left != null)
                foreach (var val in PostOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PostOrderTraversalRecursiveIterator(tree.Right))
                    yield return val;
            yield return tree;
        }

        public static IEnumerable<Node<T>> PreOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;

            yield return tree;
            if (tree.Left != null)
                foreach (var val in PreOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            if (tree.Right != null)
                foreach (var val in PreOrderTraversalRecursiveIterator(tree.Right))
                    yield return val;
        }

        public static IEnumerable<Node<T>> InOrderTraversalRecursiveIterator(Node<T> tree)
        {
            if (tree == null) yield break;
            if (tree.Left != null)
                foreach (var val in InOrderTraversalRecursiveIterator(tree.Left))
                    yield return val;
            yield return tree;
            if (tree.Right != null)
                foreach (var val in InOrderTraversalRecursiveIterator(tree.Right))
                    yield return val;
        }

        public static IEnumerable<Node<T>> BreadthFirstTraversalQueue(Node<T> node)
        {
            ////if (node == null) yield break;

            ////yield return node;
            ////var queue = new AbstractDataType.QueueSinglyLinkedList<Node<T>>();
            ////queue.Enqueue(node);
            ////while (!queue.IsEmpty)
            ////{
            ////    var parent = 
            ////}
            throw new NotImplementedException();

        }
    }

    public class Node<T> : IEnumerable<Node<T>>
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

        public IEnumerable<Node<T>> EnumerateLR()
        {
            yield return Left;
            yield return Right;
        }

        public IEnumerable<Node<T>> EnumerateRL()
        {
            yield return Right;
            yield return Left;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            return (IEnumerator<Node<T>> )EnumerateLR();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
