using DataStructures.Graph;
using System.Collections;
using Xunit;
using System;

namespace DataStructures.Tests
{
    public class GraphTests
    {
        IDictionary graph0 = new Hashtable();

        public GraphTests()
        {
            var graph0Graph = new DirectedGraphAdjacencyList<char>();
            var _A = new DirectedGraphAdjacencyList<char>.Node('A');
            var _B = new DirectedGraphAdjacencyList<char>.Node('B');
            var _C = new DirectedGraphAdjacencyList<char>.Node('C');
            var _D = new DirectedGraphAdjacencyList<char>.Node('D');
            var _E = new DirectedGraphAdjacencyList<char>.Node('E');
            var _F = new DirectedGraphAdjacencyList<char>.Node('F');
            var _G = new DirectedGraphAdjacencyList<char>.Node('G');
            var _H = new DirectedGraphAdjacencyList<char>.Node('H');
            var _I = new DirectedGraphAdjacencyList<char>.Node('I');
            var _J = new DirectedGraphAdjacencyList<char>.Node('J');
            var _K = new DirectedGraphAdjacencyList<char>.Node('K');
            var nodes = new DirectedGraphAdjacencyList<char>.Node[]
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

            foreach(var node in nodes)
            {
                graph0Graph.Add(node);
                graph0[node.Vertex.ToString()] = node;
            }

            graph0["graph"] = graph0Graph;
            //graph0["A"] = _A;
            //graph0["J"] = _J;
            //graph0["K"] = _K;
            //graph0["G"] = _G;
            //graph0["B"] = _B;
            graph0["dft-str-start-A"] = "ABCDHEKFJI";
            graph0["dft-str-start-B"] = "";
            graph0["dft-str-start-J"] = "JIF";
            graph0["dft-str-start-K"] = "K";
            graph0["dft-str-start-G"] = "GDHEABCFJIK";
        }

        [Fact]
        public void DepthFirstTraversalRecursiveIteratorTest0()
        {
            Console.WriteLine("Depth First Traversal");
            var graph = (DirectedGraphAdjacencyList<char>)graph0["graph"];
            DirectedGraphAdjacencyList<char>.Node startNode = null;
            string traversalSequence = null;
            string str = null;
            int i = 0;

            graph.FlagNodesUnvisited();
            startNode = (DirectedGraphAdjacencyList<char>.Node)graph0["A"];
            traversalSequence = (string)graph0["dft-str-start-A"];
            i = 0;
            str = "";
            foreach(var node in graph.DepthFirstTraversalRecursiveIterator(startNode))
            {
                str += node.Vertex;
            }
            Console.WriteLine(str);
            Assert.True(str.Equals(traversalSequence));

            graph.FlagNodesUnvisited();
            startNode = (DirectedGraphAdjacencyList<char>.Node)graph0["J"];
            traversalSequence = (string)graph0["dft-str-start-J"];
            i = 0;
            str = "";
            foreach (var node in graph.DepthFirstTraversalRecursiveIterator(startNode))
            {
                str += node.Vertex;
            }
            Console.WriteLine(str);
            Assert.True(str.Equals(traversalSequence));

            graph.FlagNodesUnvisited();
            startNode = (DirectedGraphAdjacencyList<char>.Node)graph0["K"];
            traversalSequence = (string)graph0["dft-str-start-K"];
            i = 0;
            str = "";
            foreach (var node in graph.DepthFirstTraversalRecursiveIterator(startNode))
            {
                str += node.Vertex;
            }
            Console.WriteLine(str);
            Assert.True(str.Equals(traversalSequence));

            graph.FlagNodesUnvisited();
            startNode = (DirectedGraphAdjacencyList<char>.Node)graph0["G"];
            traversalSequence = (string)graph0["dft-str-start-G"];
            i = 0;
            str = "";
            foreach (var node in graph.DepthFirstTraversalRecursiveIterator(startNode))
            {
                str += node.Vertex;
            }
            Console.WriteLine(str);
            Assert.True(str.Equals(traversalSequence));
        }
        
        [Fact]
        public void NodeToStringTest()
        {
            var strCheckTmpl = "Vertex {0} with {1} adjacent nodes";
            DirectedGraphAdjacencyList<char>.Node node = null;
            string strCheck = null;

            node = (DirectedGraphAdjacencyList<char>.Node)graph0["A"];
            strCheck = String.Format(strCheckTmpl, 'A', 1);
            Assert.True(strCheck.Equals(node.ToString()));

            node = (DirectedGraphAdjacencyList<char>.Node)graph0["B"];
            strCheck = String.Format(strCheckTmpl, 'B', 3);
            Assert.True(strCheck.Equals(node.ToString()));
        }
    }
}
