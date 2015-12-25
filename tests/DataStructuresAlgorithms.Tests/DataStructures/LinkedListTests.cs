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
        protected abstract LinkedList<T> GetLinkedListImpl<T>();

        [Fact]
        public void TestFindMToLastElement()
        {
            var list = GetLinkedListImpl<int>();
            foreach (var val in fixture.FindMToLastElementArray)
            {
                list.AddLast(val);
            }
            Assert.True(list.FindMToLast(7).Value == 5);
        }

        [Fact]
        public void TestIsCyclic()
        {
            var list = GetLinkedListImpl<int>();
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
            var list = GetLinkedListImpl<char>();
            Node<char> A, B, C, D, E, F, G, H, I, J, K, L;

            list.Clear();
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
            var i = 7;
            foreach(var value in new char[] { 'H', 'I', 'J'})
            {
                Assert.False(list.IsEmpty);
                Assert.True(list.Count == i);
                var node = list.AddLast(value);
                Assert.True(node == list.Find(node));
                Assert.True(list.Count == i + 1);
                i++;
            }
            K = list.AddLast('K');
            L = list.AddLast('L');

            string toStrTest = "GBFADCEHIJKL", toStr = "";
            Assert.True(null == list.FindPrevious(G));
            Assert.True(F == list.FindPrevious(A));
            foreach(var node in list)
            {
                toStr += node.Value;
            }
            Assert.True(toStrTest.Equals(toStr));

            Assert.True(G == list.RemoveFirst());
            Assert.True(L == list.RemoveLast());
            Assert.True(E == list.Remove(E));
            Assert.True(D == list.RemoveAfter(A));
            Assert.True(C == list.RemoveBefore(E));
            Assert.True(list.Count == 7);
            Assert.True(list.Length == 7);
            Assert.True(list.FirstNode == B);
            Assert.False(list.IsCyclic);
            Assert.False(list.IsEmpty);
            Assert.True(list.LastNode == K);

            list.Clear();
            Assert.True(list.Count == 0);
            Assert.True(list.Length == 0);
            Assert.True(list.FirstNode == null);
            Assert.False(list.IsCyclic);
            Assert.True(list.IsEmpty);
            Assert.True(list.LastNode == null);
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

        protected override LinkedList<T> GetLinkedListImpl<T>()
        {
            return new SinglyLinkedList<T>();
        }
    }
}