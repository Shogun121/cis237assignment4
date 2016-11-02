using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    class GenericQueue<T> : IGenericLinkedList<T>
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
                return _head == null;
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
        public void AddToFront(T GenericData)
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
        public void AddToBack(T GenericData)
        {
            //Create a variable to point to the same place as _head (Used for adding/removing)
            Node _oldTail = _tail;
            //Create a new node.
            _tail = new Node();
            //Set the data of th enew node to the parameter.
            _tail.Data = GenericData;
            //Set Tail's pointer to oldTail.
            _tail.Next = null;        
            //Check to see if the linkedList is empty, the inital add wold have moved tail,
            //but not the head pointer.
            if(IsEmpty)
            {
                _head = _tail;
            }
            //If this is not the case, then this is not an inital add.
            //So the oldTail simply needs to be re-directed.
            else
            {
                _oldTail.Next = _tail;
            }
            //Increase the size of the linked list to correspond.
            _size++;
        }
        public T RemoveFromFront()
        {
            if(IsEmpty)
            {
                throw new Exception("List is empty");
            }
            //get the data that needs to be returned.
            T returnData = _head.Data;
            //Move the head pointer over.
            _head = _head.Next;

            /**
             * The old node no longer has any references to it, so the garbage collector can clear it 
             * */

            //Decrement linked list size.
            _size--;
            //Determine if the node that was removed was the tail node.
            if(IsEmpty)
            {
                _tail=null;
            }

            //return the data
            return returnData;
        }
        public void Display()
        {
            if(IsEmpty)
            {
                Console.WriteLine("The list is empty.");
            }
        }
        //Constructor
        public GenericQueue()
        {   //ensure all the variables are as they should start.
            _head = null;
            _tail = null;
            _size = 0;
        }
        /**
         * -----TO DO--------------
         * 
         * Rename AddToBack-> Enqueue
         * Rename RemoveFromFront->Dequeue
         * */
    }
}
