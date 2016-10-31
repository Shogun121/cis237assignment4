/**
 * Robert Cooley
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    interface IGenericStack<T>
    {
        void AddToFront(T GenericData);
        void AddToBack(T GenericData);
        T RemoveFromFront();
        void Display();
        bool IsEmpty { get; }
        int Size { get; }
    }
}
