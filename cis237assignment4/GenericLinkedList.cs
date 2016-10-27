using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericLinkedList<T>:IGenericStack<T>
    {
        protected class Node
        {
            //Node has two properties; Data to store data.
            //and Next, to point to the next node in the list.

            public T Data { get; set; }
            public Node Next { get; set; }
        }

        //Head and tail to point to the beginning and end of the list respectively.
        protected Node _head;
        protected Node _tail;

        protected int _size;

        //Sets head to null if the linked list is empty
        public bool IsEmpty
        {
            get
            {
                return _head==null;
            }
        }
        //Return the size of the Linked List.
        public int Size
        {
            get
            {
                return _size;
            }
        }
        void AddToFront(T GenericData)
        {
            //Create a variable to point to the same place as _head (Used for adding/removing)
            Node _oldHead = _head;
            //Create a new Node.
            _head = new Node();
            //Set the Data of the new Node to the Parameter.
            _head.Data = GenericData;
            //Set Head's pointer to oldHead
            _head.Next = _oldHead;
            //Increase the size of the linked list to correspond.
            _size++;
            //If the LinkedList only has one item set the tail equal to the head(one item == head & tail)
            if(_size==1)
            {
                _tail = _head;
            }
        }
    }
}
