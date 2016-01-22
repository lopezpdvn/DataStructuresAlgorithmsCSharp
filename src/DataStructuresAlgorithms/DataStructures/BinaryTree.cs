using System;
using System.Collections.Generic;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Tree.BinaryTree
{
    public class BinaryTree<T>
    {
        public INode<T> Root { get; private set; }

        public BinaryTree(INode<T> root)
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

        public static int ComputeHeight(INode<T> node)
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

        public static IEnumerable<INode<T>>
            PreOrderTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null) yield break;

            yield return node;
            foreach (var val in PreOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            foreach (var val in PreOrderTraversalRecursiveIterator(node.Right))
                yield return val;
        }

        public static IEnumerable<INode<T>>
            InOrderTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null) yield break;

            foreach (var val in InOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            yield return node;
            foreach (var val in InOrderTraversalRecursiveIterator(node.Right))
                yield return val;
        }

        public static IEnumerable<INode<T>>
            PostOrderTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null) yield break;

            foreach (var val in PostOrderTraversalRecursiveIterator(node.Left))
                yield return val;
            foreach (var val in PostOrderTraversalRecursiveIterator(node.Right))
                yield return val;
            yield return node;
        }

        public static IEnumerable<INode<T>> PreOrderTraversalIterativeIterator(
            INode<T> node, IStack<INode<T>> stack)
        {
            if (node == null) yield break;
            stack.Push(node);
            while (!stack.IsEmpty)
            {
                INode<T> curr = stack.Pop();
                yield return curr;
                foreach (var child in curr.EnumerateRL())
                {
                    stack.Push(child);
                }
            }
        }

        public static IEnumerable<INode<T>> InOrderTraversalIterativeIterator(
            INode<T> node, IStack<INode<T>> stack)
        {
            INode<T> curr = node;
            while (!stack.IsEmpty || curr != null)
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

        public static IEnumerable<INode<T>> PostOrderTraversalIterativeIterator(
            INode<T> node, IStack<INode<T>> stack)
        {
            INode<T> lastNodeVisited = null, peekNode = null;
            while(!stack.IsEmpty || node != null)
            {
                if(node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    peekNode = stack.Peek();
                    if(peekNode.Right != null && peekNode.Right != lastNodeVisited)
                    {
                        node = peekNode.Right;
                    }
                    else
                    {
                        lastNodeVisited = stack.Pop();
                        yield return lastNodeVisited;
                        node = null;
                    }
                }
            }
        }

        public static IEnumerable<INode<T>> BreadthFirstTraversalQueue(
            INode<T> node, IQueue<INode<T>> queue)
        {
            if (node == null) yield break;
            yield return node;
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

    public class Node<T> : INode<T>
    {
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }
        public T Value { get; set; }

        public Node(INode<T> left, INode<T> right, T value)
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

        public IEnumerable<INode<T>> EnumerateLR()
        {
            if(Left != null) yield return Left;
            if(Right != null) yield return Right;
        }

        public IEnumerable<INode<T>> EnumerateRL()
        {
            if (Right != null) yield return Right;
            if (Left != null) yield return Left;
        }
    }
}
