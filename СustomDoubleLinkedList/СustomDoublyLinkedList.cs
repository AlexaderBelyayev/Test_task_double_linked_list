using System;
using System.Collections;
using System.Collections.Generic;

namespace СustomDoublyLinkedList
{
    /// <summary>
    /// Node
    /// </summary>

    public class Node<T>
    {
        public  T data;
        public Node<T> prev;
        public Node<T> next;
        public Node(T d) 
        { 
            data = d; 
            prev = null;
            next = null; 
        }
    }

    /// <summary>
    /// Linked list enumerator
    /// </summary>
    public struct LinkedListEnumerator<T> : IEnumerator<T>, IEnumerator
    {
        private Node<T> head;
        private Node<T> currentLink;
        private bool startedFlag;

        public LinkedListEnumerator(Node<T> head)
        {
            this.head = head;
            this.currentLink = null;
            this.startedFlag = false;
        }

        public T Current
        {
            get { return this.currentLink.data; }
        }

        public void Dispose()
        {
            this.head = null;
           // this.tail = null;
            this.currentLink = null;
        }

        object IEnumerator.Current
        {
            get { return this.currentLink.data; }
        }

        public bool MoveNext()
        {
            if (this.startedFlag == false)
            {
                this.currentLink = this.head;
                this.startedFlag = true;
            }
            else
            {
                this.currentLink = this.currentLink.next;
            }

            return this.currentLink != null;
        }

        public void Reset()
        {
            this.currentLink = this.head;
        }
    }

    /// <summary>
    /// Doubly Linked list     
    /// </summary>

    public class DoublyLinkedList<T> : IEnumerable<T>, IEnumerable
    {
        private Node<T> _head;
        public Node<T> Head
        {
            get => _head;
            set => _head = value;
        }


        public void AddFirst(T new_data)
        {

            Node<T> new_Node = new Node<T>(new_data);

            new_Node.next = _head;
            new_Node.prev = null;

            /* change prev of head node to new node */
            if (_head != null)
                _head.prev = new_Node;

            /* move the head to point to the new node */
            _head = new_Node;
        }
        
        public void AddLast(T new_data)
        {
            Node<T> new_node = new Node<T>(new_data);

            Node<T> last = _head; 

            new_node.next = null;

            /* If the Linked List is empty,
            then make the new * node as head */
            if (_head == null)
            {
                new_node.prev = null;
                _head = new_node;
                return;
            }

            /* Else traverse till the last node */
            while (last.next != null)
                last = last.next;

            /* Change the next of last node */
            last.next = new_node;

            /* Make last node as previous of new node */
            new_node.prev = last;
        }

        public void Remove(Node<T> del)
        {
            if (del == null)
            {
                throw new ArgumentNullException("node");
            }
           
            if (_head == null)
            {
                return;
            }

            // If node to be deleted is head node
            if (_head == del)
            {
                _head = del.next;
            }

            // Change next only if node to be deleted
            // is NOT the last node
            if (del.next != null)
            {
                del.next.prev = del.prev;
            }

            // Change prev only if node to be deleted
            // is NOT the first node
            if (del.prev != null)
            {
                del.prev.next = del.next;
            }

            // Finally, free the memory occupied by del
            return;
        }


        //public IEnumerator Enumerator()
        //{
        //    //var current = _head;
        //    //while (current != null)
        //    //{
        //    //    yield return current.data;
        //    //    current = current.next;
        //    //}

        //    return new LinkedListEnumerator<>(_head);
        //}

        public LinkedListEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        // to find the last node of linked list
        private Node<T> LastNode(Node<T> node)
        {
            while (node.next != null)
                node = node.next;
            return node;
        }

        private Node<T> Partition(Node<T> last, Node<T> head)
        {
            // set pivot as h element
            T pivot = head.data;

            // similar to i = l-1 for array implementation
            Node<T> i = last.prev;
            T temp;
            var comparer = Comparer<T>.Default;
          
            // Similar to "for (int j = l; j <= h- 1; j++)"
            for (Node<T> j = last; j != head; j = j.next)
            {
                if (comparer.Compare(pivot,j.data)==0 || comparer.Compare(pivot, j.data)> 0)
                //if (j.data <= pivot)
                {
                    // Similar to i++ for array
                    i = (i == null) ? last : i.next;
                    temp = i.data;
                    i.data = j.data;
                    j.data = temp;
                }
            }
            i = (i == null) ? last : i.next; // Similar to i++
            temp = i.data;
            i.data = head.data;
            head.data = temp;
            return i;
        }

        /* A recursive implementation of
       quicksort for linked list */
        private void RecursiveQuickSort(Node<T> last, Node<T> head)
        {
            if (head != null && last != head && last != head.next)
            {
                Node<T> temp = Partition(last, head);
                RecursiveQuickSort(last, temp.prev);
                RecursiveQuickSort(temp.next, head);
            }
        }
        public void QuickSort()
        {
            // Find last node
            Node<T> last = LastNode(_head);

            // Call the recursive QuickSort
            RecursiveQuickSort(_head, last);
        }

       
    }
}
