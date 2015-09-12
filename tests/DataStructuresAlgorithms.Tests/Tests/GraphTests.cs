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
            graph0["graph"] = graph0Graph;
            graph0["A"] = _A;
        }

        [Fact]
        public void DepthFirstTraversalTest0()
        {


            Console.WriteLine("Depth First Traversal");
            var graph = (DirectedGraphAdjacencyList<char>)graph0["graph"];
            var startNode = (DirectedGraphAdjacencyList<char>.Node)graph0["A"];
            Console.WriteLine(graph.DepthFirstTraversal(startNode));
        }
    }
}
