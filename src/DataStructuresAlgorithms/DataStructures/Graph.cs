using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructuresAlgorithms.DataStructures.LinkedList;
using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Graph
{
    // Based in code from
    // https://github.com/gaylemcd/ctci/blob/master/c-sharp/Chapter04/Q04_2.cs
    public class DirectedGraphAdjacencyList<T> :
        IEnumerable<Node<T>>
    {
        public SinglyLinkedList<Node<T>> Nodes { get; private set; }
        public int Count { get; private set; }
        public IQueue<Node<T>> Queue { get; set; }
        public IStack<Node<T>> Stack { get; set; }

        public DirectedGraphAdjacencyList()
        {
            Nodes = new SinglyLinkedList<Node<T>>();
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

        public void Add(Node<T> node)
        {
            Nodes.Add(node);
            Count++;
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            foreach(var node in Nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Node<T>>
            PreOrderDepthFirstTraversalRecursiveIterator(Node<T> node)
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

        private IEnumerable<Node<T>>
            _PreOrderDepthFirstTraversalRecursiveIterator(Node<T> node)
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

        public IEnumerable<Node<T>>
            PreOrderDepthFirstTraversalIterativeIterator(Node<T> node)
        {
            if (node == null)
            {
                yield break;
            }

            Node<T> curr = null;
            var stack = new StackSinglyLinkedList<Node<T>>();
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

        public IEnumerable<Node<T>>
            BreadthFirstTraversalIterativeIterator(Node<T> node)
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

        public IEnumerable<Node<T>>
            BreadthFirstTraversalIterativeIterator(Node<T> node, IQueue<Node<T>> queue)
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

    public class Node<T> : IEnumerable<Node<T>>
    {
        private ILinkedList<Node<T>> adjacent =
            new SinglyLinkedList<Node<T>>();
        public int Count { get; private set; }
        public T Vertex { get; set; }
        public State State { get; set; }

        public Node(T vertex)
        {
            Vertex = vertex;
        }

        public void AddAdjacent(params Node<T>[] nodes)
        {
            foreach (var node in nodes)
            {
                adjacent.Add(node);
                Count++;
            }
        }

        public IEnumerator<Node<T>> GetEnumerator()
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
