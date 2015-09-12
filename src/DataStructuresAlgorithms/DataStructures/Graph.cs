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
        private SinglyLinkedList<Node> nodes = new SinglyLinkedList<Node>();
        public int Count { get; private set; }

        public void Add(Node node)
        {
            nodes.Add(node);
            Count++;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            foreach(var node in nodes)
                yield return node.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

            public void AddAdjacent(Node node)
            {
                adjacent.Add(node);
                Count++;
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
