using System;
using System.Collections.Generic;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Tree
{
    public class BinaryTree<T>
    {
        public Node<T> Root { get; private set; }

        public BinaryTree(Node<T> root)
        {
            Root = root;
        }

        public BinaryTree() : this(null) { }

        private static IStack<Node<T>> GetStackImpl()
        {
            return new StackSinglyLinkedList<Node<T>>();
        }

        private static IQueue<Node<T>> GetQueueImpl()
        {
            return new QueueSinglyLinkedList<Node<T>>();
        }

        public int Height
        {
            get
            {
                return ComputeHeight(Root);
            }
        }

        public static int ComputeHeight(Node<T> node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                return 1 + Math.Max(ComputeHeight(node.Left),
                    ComputeHeight(node.Right));
            }
        }

        public static IEnumerable<Node<T>> PreOrderTraversalRecursiveIterator(Node<T> node)
        {
            if (node == null) yield break;

            yield return node;
            foreach (var val in PreOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            foreach (var val in PreOrderTraversalRecursiveIterator(node.Right))
                yield return val;
        }

        public static IEnumerable<Node<T>> InOrderTraversalRecursiveIterator(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var val in InOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            yield return node;
            foreach (var val in InOrderTraversalRecursiveIterator(node.Right))
                yield return val;
        }

        public static IEnumerable<Node<T>> PostOrderTraversalRecursiveIterator(Node<T> node)
        {
            if (node == null) yield break;

            foreach (var val in PostOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            foreach (var val in PostOrderTraversalRecursiveIterator(node.Right))
                yield return val;
            yield return node;
        }

        public static IEnumerable<Node<T>> PreOrderTraversalIterativeIterator(Node<T> node)
        {
            if (node == null) yield break;

            IStack<Node<T>> stack = GetStackImpl();
            stack.Push(node);
            while (stack.Count > 0)
            {
                Node<T> curr = stack.Pop();
                yield return curr;
                foreach (var child in curr.EnumerateRL())
                {
                    stack.Push(child);
                }
            }
        }

        public static IEnumerable<Node<T>> InOrderTraversalIterativeIterator(Node<T> node)
        {
            IStack<Node<T>> stack = GetStackImpl();
            Node<T> curr = node;
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

        public static IEnumerable<Node<T>> PostOrderTraversalIterativeIterator(Node<T> node)
        {
            IStack<Node<T>> stack = GetStackImpl();
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
                    peekNode = stack.Peek();
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

        public static IEnumerable<Node<T>> BreadthFirstTraversalQueue(Node<T> node)
        {
            if (node == null) yield break;

            yield return node;
            IQueue<Node<T>> queue = GetQueueImpl();
            queue.Enqueue(node);
            while (!queue.IsEmpty)
            {
                var parent = queue.Dequeue();
                foreach(var child in parent.EnumerateLR())
                {
                    yield return child;
                    queue.Enqueue(child);
                }
            }
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

        public IEnumerable<Node<T>> EnumerateLR()
        {
            if(Left != null) yield return Left;
            if(Right != null) yield return Right;
        }

        public IEnumerable<Node<T>> EnumerateRL()
        {
            if (Right != null) yield return Right;
            if (Left != null) yield return Left;
        }
    }
}
