using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using ÑustomDoublyLinkedList;
using System.Collections.Generic;
using System.Linq;

namespace CustomDoublyLinkedListTest
{
    [TestClass]
    public class ÑustomDoublyLinkedListTest
    {
 
        [TestMethod]
        public void AddFistTestWhenListIsEmpty()
        {
            // Adding a node at the front of the list            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            list.AddFirst(10);
            //assert
            Assert.IsNull(list.Head.prev);
            Assert.IsNull(list.Head.next);
            Assert.AreEqual(list.Head.data, 10);

        }

        [TestMethod]
        public void AddFistTestWhenListIsNotEmpty()
        {
            // Adding a node at the front of the list            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            list.AddFirst(10);
            list.AddFirst(11);
            //assert
            Assert.IsNull(list.Head.prev);
            Assert.IsNotNull(list.Head.next);
            Assert.AreEqual(list.Head.data, 11);

        }

        [TestMethod]
        public void AddingTenNodesUsingAddFirst()
        {
            // Adding a node at the front of the list            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            StringBuilder insb = new StringBuilder();
            for (int i = 1; i < 11; i++)
            {
                insb.Append(11-i);
                list.AddFirst(i);
            }
            StringBuilder outpsb = new StringBuilder();
            foreach (var l in list)
                outpsb.Append(l);
            //assert
            Assert.AreEqual(insb.ToString(), outpsb.ToString());
        }


        [TestMethod]
        public void AddLastTestWhenListIsEmpty()
        {
            // Adding a node at the end of the list 
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            list.AddLast(100);
            Assert.IsNull(list.Head.next);
            Assert.IsNull(list.Head.prev);
            Assert.AreEqual(list.Head.data, 100);

        }

        [TestMethod]
        public void AddLastTestWhenListIsNotEmpty()
        {
            // Adding a node at the end of the list 
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(100);
            list.AddLast(101);
            Assert.IsNull(list.Head.next.next);
            Assert.IsNotNull(list.Head.next.prev);
            Assert.AreEqual(list.Head.next.data, 101);

        }

        [TestMethod]
        public void AddingTenNodesUsingAddLast()
        {
            // Adding a node at the front of the list            
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            StringBuilder insb = new StringBuilder();
            for (int i = 1; i < 11; i++)
            {
                insb.Append(i);
                list.AddLast(i);
            }
            StringBuilder outpsb = new StringBuilder();
            foreach (var l in list)
                outpsb.Append(l);
            //assert
            Assert.AreEqual(insb.ToString(), outpsb.ToString());
        }
        [TestMethod]
        public void RemoveNodeIfItIsNullTest()
        {
            //Removing a node from list
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddLast(10);
            list.AddLast(100);  
            // Act and assert
            Assert.ThrowsException<System.ArgumentNullException>(() => list.Remove(null));

        }

        [TestMethod]
        public void RemoveNodeTest()
        {
            //Removing a node from list
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            list.AddLast(10);
            Node<int> first = list.Head; 
            list.AddLast(100);
            Node<int> second = list.Head.next;
            list.AddLast(1000);
            Node<int> third = list.Head.next.next;
            list.Remove(first);
            //assert
            Assert.AreEqual(list.Head.data, second.data);
                
        }

        [TestMethod]
        public void QuickSortTest()
        {
            //Removing a node from list
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            //act
            list.AddLast(10);
            list.AddLast(11);
            list.AddLast(1);
            list.AddFirst(5);
            list.AddFirst(100);
            list.AddLast(65);
            list.AddLast(22);
            var clist = new List<int>(list);
            clist.Sort();
            list.QuickSort();
           Assert.IsTrue(Enumerable.SequenceEqual(clist, list));

        }




    }
}
