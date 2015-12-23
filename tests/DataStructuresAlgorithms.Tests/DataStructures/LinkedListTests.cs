using Xunit;
using DataStructuresAlgorithms.DataStructures.LinkedList;
using DataStructuresAlgorithms.DataStructures.LinkedList.SinglyLinkedList;
using System;

namespace DataStructuresAlgorithms.Tests.DataStructures
{
    public class LinkedListTestFixture
    {
        public int[] FindMToLastElementArray = 
            { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
    }

    public abstract class LinkedListsTests
    {
        protected LinkedListTestFixture fixture;
        protected abstract LinkedList<int> GetLinkedListImpl();

        [Fact]
        public void TestFindMToLastElement()
        {
            LinkedList<int> list = GetLinkedListImpl();
            foreach (var val in fixture.FindMToLastElementArray)
            {
                list.AddLast(val);
            }
            Assert.True(list.FindMToLast(7).Value == 5);
        }

        [Fact]
        public void TestIsCyclic()
        {
            var list = GetLinkedListImpl();
            for (int i = 0; i < 20; i++)
            {
                list.AddLast(i);
            }
            Console.WriteLine(list);
            Assert.True(list.LastNode.Next == null);

            Assert.False(list.IsCyclic);

            // making list cyclic
            var middleNode = list.FirstNode.Next.Next.Next;
            list.LastNode.Next = middleNode;
            Assert.True(list.LastNode.Next == list.FirstNode.Next.Next.Next);

            Assert.True(list.IsCyclic);
        }

        [Fact]
        public void MiscTests0()
        {
            LinkedList<char> list = new SinglyLinkedList<char>();
            Node<char> A, B, C, D, E, F, G, H, I, J, K, L;

            Assert.True(list.Count == 0);
            Assert.True(list.Length == 0);
            Assert.True(list.FirstNode == null);
            Assert.False(list.IsCyclic);
            Assert.True(list.IsEmpty);
            Assert.True(list.LastNode == null);

            A = list.Add('A');
            Assert.True(list.FirstNode == A);
            Assert.True(list.LastNode == A);
            B = list.AddFirst('B');
            C = list.AddLast('C');
            D = list.AddAfter(A, 'D');
            E = list.AddAfter(C, 'E');
            F = list.AddBefore(A, 'F');
            G = list.AddBefore(B, 'G');
            foreach(var value in new char[] { 'H', 'I', 'J', 'K', 'L'})
            {
                list.AddLast(value);
            }

            string toStrTest = "GBFADCE", toStr = "";
            foreach(var node in list)
            {
                toStr += node.Value;
            }
            Assert.True(toStrTest.Equals(toStr));
        }
    }

    [CollectionDefinition("Linked List Collection")]
    public class LinkedListCollection :
        ICollectionFixture<LinkedListTestFixture> { }

    [Collection("Linked List Collection")]
    public class SinglyLinkedListTests : LinkedListsTests
    {
        public SinglyLinkedListTests(LinkedListTestFixture fixture)
        {
            this.fixture = fixture;
        }

        protected override LinkedList<int> GetLinkedListImpl()
        {
            return new SinglyLinkedList<int>();
        }
    }
}