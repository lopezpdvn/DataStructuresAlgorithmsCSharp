using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.DataStructures.Graph
{
    // Based in code from
    // https://github.com/gaylemcd/ctci/blob/master/c-sharp/Chapter04/Q04_2.cs
    public class DirectedGraphAdjacencyList<T> :
        IEnumerable<DirectedGraphAdjacencyList<T>.Node>
    {
        public SinglyLinkedList<Node> Nodes { get; private set; }
        public int Count { get; private set; }

        public DirectedGraphAdjacencyList()
        {
            Nodes = new SinglyLinkedList<Node>();
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

        public void Add(Node node)
        {
            Nodes.Add(node);
            Count++;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach(var node in Nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<Node>
            PreOrderDepthFirstTraversalRecursiveIterator(Node node)
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

        private IEnumerable<Node>
            _PreOrderDepthFirstTraversalRecursiveIterator(Node node)
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

        public IEnumerable<Node>
            PreOrderDepthFirstTraversalIterativeIterator(Node node)
        {
            if (node == null)
            {
                yield break;
            }

            Node curr = null;
            var stack = new StackSinglyLinkedList<Node>();
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

        public IEnumerable<Node>
            BreadthFirstTraversalIterativeIterator(Node node)
        {
            if (node == null || node.State == State.Visited)
            {
                yield break;
            }

            yield return node;
            node.State = State.Visited;
            var queue = new QueueSinglyLinkedList<Node>();
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

        public enum State
        {
            Unvisited, Visited
        }

        public class Node : IEnumerable<Node>
        {
            private SinglyLinkedList<Node> adjacent =
                new SinglyLinkedList<Node>();
            public int Count { get; private set; }
            public T Vertex { get; set; }
            public State State { get; set; }

            public Node(T vertex)
            {
                Vertex = vertex;
            }

            public void AddAdjacent(params Node[] nodes)
            {
                foreach(var node in nodes)
                {
                    adjacent.Add(node);
                    Count++;
                }
            }

            public IEnumerator<Node> GetEnumerator()
            {
                foreach(var node in adjacent)
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
}
