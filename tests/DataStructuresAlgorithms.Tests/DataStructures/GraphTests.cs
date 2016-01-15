using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using DataStructuresAlgorithms.DataStructures.Graph;
using DataStructuresAlgorithms.AbstractDataTypes;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class GraphTraversalFixture
    {
        public IDictionary graph0 = new Hashtable();
        public IDictionary graph1 = new Hashtable();

        public GraphTraversalFixture()
        {
            var graph0Graph = new DirectedGraphAdjacencyList<char>();
            var _A = new Node<char>('A');
            var _B = new Node<char>('B');
            var _C = new Node<char>('C');
            var _D = new Node<char>('D');
            var _E = new Node<char>('E');
            var _F = new Node<char>('F');
            var _G = new Node<char>('G');
            var _H = new Node<char>('H');
            var _I = new Node<char>('I');
            var _J = new Node<char>('J');
            var _K = new Node<char>('K');
            var nodes = new Node<char>[]
                { _A, _B, _C, _D, _E, _F, _G, _H, _I, _J, _K };
            _A.AddAdjacent(_B);
            _B.AddAdjacent(_A, _C, _J);
            _C.AddAdjacent(_D, _F);
            _D.AddAdjacent(_H);
            _E.AddAdjacent(_A, _D);
            //_F.AddAdjacent();
            _G.AddAdjacent(_D, _I);
            _H.AddAdjacent(_D, _E, _K);
            _I.AddAdjacent(_F);
            _J.AddAdjacent(_I);
            //_K.AddAdjacent();

            foreach (var node in nodes)
            {
                graph0Graph.Add(node);
                var nodeKey = node.Vertex.ToString();
                graph0[nodeKey] = new Hashtable();
                ((Hashtable)graph0[nodeKey])["node"] = node;
            }

            graph0Graph.Queue = new QueueSinglyLinkedList<
                INode<char>>();

            graph0["graph"] = graph0Graph;
            ((Hashtable)graph0["A"])["dft-string"] = "ABCDHEKFJI";
            ((Hashtable)graph0["B"])["dft-string"] = "BACDHEKFJI";
            ((Hashtable)graph0["C"])["dft-string"] = "CDHEABJIFK";
            ((Hashtable)graph0["D"])["dft-string"] = "DHEABCFJIK";
            ((Hashtable)graph0["E"])["dft-string"] = "EABCDHKFJI";
            ((Hashtable)graph0["F"])["dft-string"] = "F";
            ((Hashtable)graph0["G"])["dft-string"] = "GDHEABCFJIK";
            ((Hashtable)graph0["H"])["dft-string"] = "HDEABCFJIK";
            ((Hashtable)graph0["I"])["dft-string"] = "IF";
            ((Hashtable)graph0["J"])["dft-string"] = "JIF";
            ((Hashtable)graph0["K"])["dft-string"] = "K";


            ((Hashtable)graph0["A"])["bft-string"] = "ABCJDFIHEK";
            ((Hashtable)graph0["B"])["bft-string"] = "BACJDFIHEK";
            ((Hashtable)graph0["C"])["bft-string"] = "CDFHEKABJI";
            ((Hashtable)graph0["D"])["bft-string"] = "DHEKABCJFI";
            ((Hashtable)graph0["E"])["bft-string"] = "EADBHCJKFI";
            ((Hashtable)graph0["F"])["bft-string"] = "F";
            ((Hashtable)graph0["G"])["bft-string"] = "GDIHFEKABCJ";
            ((Hashtable)graph0["H"])["bft-string"] = "HDEKABCJFI";
            ((Hashtable)graph0["I"])["bft-string"] = "IF";
            ((Hashtable)graph0["J"])["bft-string"] = "JIF";
            ((Hashtable)graph0["K"])["bft-string"] = "K";

            var graph1Graph = new DirectedGraphAdjacencyList<char>();
            graph1["graph"] = graph1Graph;
        }
    }

    public abstract class GraphTraversalTests
    {
        protected GraphTraversalFixture fixture;
        protected Func<INode<char>,
            IEnumerable<INode<char>>>
            TraversalAlgorithm;
        protected string traversalType;
        protected DirectedGraphAdjacencyList<char> graph;

        [Fact]
        public void TraversalTest0()
        {
            graph = (DirectedGraphAdjacencyList<char>)fixture.graph0["graph"];
            Node<char> startNode = null;
            string traversalSequence = null;
            string str = null;
            var nodeKeys = new string[]
                { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

            foreach (var nodeKey in nodeKeys)
            {
                graph.FlagNodesUnvisited();
                str = "";
                startNode = (Node<char>)
                    ((Hashtable)fixture.graph0[nodeKey])["node"];
                traversalSequence = (string)
                    ((Hashtable)fixture.graph0[nodeKey])[traversalType];
                foreach (var node in TraversalAlgorithm(startNode))
                {
                    str += node.Vertex;
                }
                Console.WriteLine(str);
                Assert.True(str.Equals(traversalSequence));
            }
        }

        [Fact]
        public void NullGraphTraversalTest()
        {
            graph = (DirectedGraphAdjacencyList<char>)fixture.graph1["graph"];
            Node<char> startNode = null;
            string traversalSequence = "", str = "";
            graph.FlagNodesUnvisited();
            foreach (var node in TraversalAlgorithm(startNode))
            {
                str += node.Vertex;
            }
            Assert.True(str.Equals(traversalSequence));
        }
    }

    [CollectionDefinition("Graph Traversal Collection")]
    public class GraphTraversalCollection :
        ICollectionFixture<GraphTraversalFixture> { }

    [Collection("Graph Traversal Collection")]
    public class DirectedGraphAdjacencyListPreOrderDFTraversalRecursiveIterator
        : GraphTraversalTests
    {
        public DirectedGraphAdjacencyListPreOrderDFTraversalRecursiveIterator(
            GraphTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-string";
            TraversalAlgorithm =
                ((DirectedGraphAdjacencyList<char>)fixture.graph0["graph"])
                .PreOrderDepthFirstTraversalRecursiveIterator;
        }
    }

    [Collection("Graph Traversal Collection")]
    public class DirectedGraphAdjacencyListPreOrderDFTraversalIterativeIterator
    : GraphTraversalTests
    {
        public DirectedGraphAdjacencyListPreOrderDFTraversalIterativeIterator(
            GraphTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "dft-string";
            TraversalAlgorithm =
                ((DirectedGraphAdjacencyList<char>)fixture.graph0["graph"])
                .PreOrderDepthFirstTraversalIterativeIterator;
        }
    }

    [Collection("Graph Traversal Collection")]
    public class DirectedGraphAdjacencyListBFTraversalIterator
        : GraphTraversalTests
    {
        public DirectedGraphAdjacencyListBFTraversalIterator(
            GraphTraversalFixture fixture)
        {
            this.fixture = fixture;
            traversalType = "bft-string";
            TraversalAlgorithm =
                ((DirectedGraphAdjacencyList<char>)fixture.graph0["graph"])
                .BreadthFirstTraversalIterativeIterator;
        }
    }

    [Collection("Graph Traversal Collection")]
    public class GraphTests0
    {
        GraphTraversalFixture fixture;

        public GraphTests0(GraphTraversalFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void NodeToStringTest()
        {
            var strCheckTmpl = "Vertex {0} with {1} adjacent nodes";
            Node<char> node = null;
            string strCheck = null;

            node = (Node<char>)
                ((Hashtable)fixture.graph0["A"])["node"];
            strCheck = String.Format(strCheckTmpl, 'A', 1);
            Assert.True(strCheck.Equals(node.ToString()));

            node = (Node<char>)
                ((Hashtable)fixture.graph0["B"])["node"];
            strCheck = String.Format(strCheckTmpl, 'B', 3);
            Assert.True(strCheck.Equals(node.ToString()));
        }
    }
}