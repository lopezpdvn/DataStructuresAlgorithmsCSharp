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

        // Empty tree.
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
            if (node == null)
            {
                yield break;
            }
            yield return node;
            foreach (var iNode in
                PreOrderTraversalRecursiveIterator(node.Left))
            {
                yield return iNode;
            }
            foreach (var iNode in
                PreOrderTraversalRecursiveIterator(node.Right))
            {
                yield return iNode;
            }
        }

        public static IEnumerable<INode<T>>
            InOrderTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            foreach (var iNode in InOrderTraversalRecursiveIterator(node.Left))
            {
                yield return iNode;
            }
            yield return node;
            foreach (var iNode in
                InOrderTraversalRecursiveIterator(node.Right))
            {
                yield return iNode;
            }
        }

        public static IEnumerable<INode<T>>
            PostOrderTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null)
            {
                yield break;
            }
            foreach (var iNode in
                PostOrderTraversalRecursiveIterator(node.Left))
            {
                yield return iNode;
            }
            foreach (var iNode in
                PostOrderTraversalRecursiveIterator(node.Right))
            {
                yield return iNode;
            }
            yield return node;
        }

        public static IEnumerable<INode<T>> PreOrderTraversalIterativeIterator(
            INode<T> node, IStack<INode<T>> stack)
        {
            if (node == null)
            {
                yield break;
            }
            stack.Push(node);
            while (!stack.IsEmpty)
            {
                node = stack.Pop();
                yield return node;
                foreach (var childNode in node.EnumerateRL())
                {
                    stack.Push(childNode);
                }
            }
        }

        public static IEnumerable<INode<T>> InOrderTraversalIterativeIterator(
            INode<T> node, IStack<INode<T>> stack)
        {
            while (!stack.IsEmpty || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node;
                    node = node.Right;
                }
            }
        }

        public static IEnumerable<INode<T>>
            PostOrderTraversalIterativeIterator(
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

        public static IEnumerable<INode<T>>
            BreadthFirstTraversalIterativeIterator(INode<T> node,
            IQueue<INode<T>> queue)
        {
            if (node == null)
            {
                yield break;
            }
            yield return node;
            queue.Enqueue(node);
            while (!queue.IsEmpty)
            {
                node = queue.Dequeue();
                foreach(var childNode in node.EnumerateLR())
                {
                    yield return childNode;
                    queue.Enqueue(childNode);
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
            if (Left != null)
            {
                yield return Left;
            }
            if (Right != null)
            {
                yield return Right;
            }
        }

        public IEnumerable<INode<T>> EnumerateRL()
        {
            if (Right != null)
            {
                yield return Right;
            }
            if (Left != null)
            {
                yield return Left;
            }
        }
    }
}
