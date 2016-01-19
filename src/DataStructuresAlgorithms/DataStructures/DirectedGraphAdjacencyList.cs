using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructuresAlgorithms.DataStructures.LinkedList;
using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Graph.DirectedGraphAdjacencyList
{
    public class DirectedGraphAdjacencyList<T> : IGraph<T>
    {
        public ILinkedList<INode<T>> Nodes { get; private set; }
        public int Count { get; private set; }
        public IQueue<INode<T>> Queue { get; set; }
        public IStack<INode<T>> Stack { get; set; }

        public DirectedGraphAdjacencyList()
        {
            Nodes = new SinglyLinkedList<INode<T>>();
        }

        public DirectedGraphAdjacencyList(ILinkedList<INode<T>> nodeList,
            IStack<INode<T>> stack, IQueue<INode<T>> queue)
        {
            Nodes = nodeList;
            Stack = stack;
            Queue = queue;
        }

        public void FlagNodes(State state = State.Unvisited)
        {
            foreach(var node in this)
                node.State = state;
        }

        public void FlagNodesUnvisited()
        {
            FlagNodes(State.Unvisited);
        }

        public void Add(INode<T> node)
        {
            Nodes.Add(node);
            Count++;
        }

        public IEnumerator<INode<T>> GetEnumerator()
        {
            foreach(var node in Nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static IEnumerable<INode<T>>
            PreOrderDepthFirstTraversalRecursiveIterator(INode<T> node)
        {
            if (node == null || node.State == State.Visited)
            {
                yield break;
            }
            foreach(var adjNode in
                _PreOrderDepthFirstTraversalRecursiveIterator(node))
            {
                yield return adjNode;
            }
        }

        private static IEnumerable<INode<T>>
            _PreOrderDepthFirstTraversalRecursiveIterator(INode<T> node)
        {
            yield return node;
            node.State = State.Visited;

            foreach (var adjNode in node)
            {
                if (adjNode.State == State.Unvisited)
                {
                    foreach (var iAdjNode in
                        _PreOrderDepthFirstTraversalRecursiveIterator(adjNode))
                    {
                        yield return iAdjNode;
                    }
                }
            }
        }

        public static IEnumerable<INode<T>>
            PreOrderDepthFirstTraversalIterativeIterator(INode<T> node,
            IStack<INode<T>> stack)
        {
            if (node == null)
            {
                yield break;
            }
            stack.Push(node);
            while (stack.Count > 0)
            {
                node = stack.Pop();
                if(node.State == State.Unvisited)
                {
                    yield return node;
                    node.State = State.Visited;
                    foreach (var adjacentNode in node.Reverse())
                    {
                        stack.Push(adjacentNode);
                    }
                }
            }
        }

        public static IEnumerable<INode<T>>
            BreadthFirstTraversalIterativeIterator(INode<T> node,
            IQueue<INode<T>> queue)
        {
            if (node == null || node.State == State.Visited)
            {
                yield break;
            }

            yield return node;
            node.State = State.Visited;
            queue.Enqueue(node);

            while (!queue.IsEmpty)
            {
                node = queue.Dequeue();
                foreach (var adjacentNode in node)
                {
                    if(adjacentNode.State == State.Unvisited)
                    {
                        yield return adjacentNode;
                        adjacentNode.State = State.Visited;
                        queue.Enqueue(adjacentNode);
                    }
                }
            }
        }
    }

    public class Node<T> : INode<T>
    {
        private ILinkedList<INode<T>> adjacent =
            new SinglyLinkedList<INode<T>>();
        public int Count { get; private set; }
        public T Vertex { get; set; }
        public State State { get; set; }

        public Node(T vertex)
        {
            Vertex = vertex;
        }

        public void AddAdjacent(params INode<T>[] nodes)
        {
            foreach (var node in nodes)
            {
                adjacent.Add(node);
                Count++;
            }
        }

        public IEnumerator<INode<T>> GetEnumerator()
        {
            foreach (var node in adjacent)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("Vertex {0} with {1} adjacent nodes",
                Vertex, Count);
        }
    }
}
