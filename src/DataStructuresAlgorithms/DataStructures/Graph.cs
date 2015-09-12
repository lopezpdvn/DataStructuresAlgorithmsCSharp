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
        private string str = "";

        public DirectedGraphAdjacencyList()
        {
            Nodes = new SinglyLinkedList<Node>();
        }

        public void FlagNodes(State state = State.Unvisited)
        {
            foreach(var node in this)
                node.State = state;
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

        public string DepthFirstTraversal(Node startNode, bool flagUnvisited = false)
        {
            if (flagUnvisited)
                foreach (var node in this)
                    node.State = State.Unvisited;

            if (startNode == null) return str;

            str += startNode.Vertex.ToString();
            startNode.State = State.Visited;

            foreach(var n in startNode)
                if (n.State == State.Unvisited)
                    DepthFirstTraversal(n);

            return str;
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
        }


    }
}
