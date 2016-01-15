using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructuresAlgorithms.DataStructures.LinkedList;
using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Graph
{
    public interface INode<T> : IEnumerable<INode<T>>
    {
        int Count { get; }
        T Vertex { get; set; }
        State State { get; set; }
        void AddAdjacent(params INode<T>[] nodes);
    }

    public class DirectedGraphAdjacencyList<T> :
        IEnumerable<INode<T>>
    {
        public ILinkedList<INode<T>> Nodes { get; private set; }
        public int Count { get; private set; }
        public IQueue<INode<T>> Queue { get; set; }
        public IStack<INode<T>> Stack { get; set; }

        public DirectedGraphAdjacencyList()
        {
            Nodes = new SinglyLinkedList<INode<T>>();
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

        public IEnumerable<INode<T>>
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

        private IEnumerable<INode<T>>
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

        public IEnumerable<INode<T>>
            PreOrderDepthFirstTraversalIterativeIterator(INode<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            INode<T> curr = null;
            var stack = new StackSinglyLinkedList<INode<T>>();
            stack.Push(node);

            while (stack.Count > 0)
            {
                curr = stack.Pop();
                if(curr.State == State.Unvisited)
                {
                    yield return curr;
                    curr.State = State.Visited;
                    foreach (var adjacentNode in curr.Reverse())
                    {
                        stack.Push(adjacentNode);
                    }
                }
            }
        }

        public IEnumerable<INode<T>>
            BreadthFirstTraversalIterativeIterator(INode<T> node)
        {
            // Queue.Clear();
            for (var i = 0; i < Queue.Count; i++)
            {
                Queue.Dequeue();
            }
            foreach(var iNode in BreadthFirstTraversalIterativeIterator(node, Queue))
            {
                yield return iNode;
            }
        }

        public IEnumerable<INode<T>>
            BreadthFirstTraversalIterativeIterator(INode<T> node, IQueue<INode<T>> queue)
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

    public enum State
    {
        Unvisited, Visited
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
