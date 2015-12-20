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