using System;
using System.Collections;
using System.Collections.Generic;
using DataStructures.LinkedList;

namespace DataStructures.Graph
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

        public IEnumerable<Node> DepthFirstTraversalRecursiveIterator(Node node)
        {
            if (node == null) yield break;

            yield return node;
            node.State = State.Visited;

            foreach (var adjacentNode in node)
                if(adjacentNode.State == State.Unvisited)
                    foreach(var adjacentNodeChild in DepthFirstTraversalRecursiveIterator(adjacentNode))
                        yield return adjacentNodeChild;
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
                return String.Format("Vertex {0} with {1} adjacent nodes",
                    Vertex, Count);
            }
        }
    }
}
