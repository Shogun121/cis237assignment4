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
    class MergeSort
    {
        IComparable[] aux = new IComparable[arr.length];
        /// <summary>
        /// Method to sort the array.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public void Sort(IComparable[] arr,int low, int high)
        {
            
            if(high<=low)   //base case
            {
                return;
            }
            int Mid=low+(high-low)/2;    //Calc midpoint
            Sort(arr,low,Mid);  //Left hand split
            Sort(arr,Mid+1,high);   //Right hand split
            Merge(arr,low,Mid,high);    //Merge left and right
        }
        /// <summary>
        /// Method to reassemble the array after it has been sorted.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="Mid"></param>
        /// <param name="high"></param>
        public void Merge(IComparable[] arr, int low, int Mid, int high)
        {
            //index variables
            int i = low;
            int j = Mid + 1;

            //create a duplicate array to rearrange from.
            for (int K = low; K <= high; K++)
            {
                //duplicate one index at a time.
                aux[K] = arr[K];
            }
            //Sort
            for (int K = low; K <= high;K++)
            {
                if(i>Mid)   //If past end
                {
                    arr[K] = aux[j++];
                }
                else if(j>high)    //If past end.
                {
                    arr[K] = aux[i++];
                }
                    //If the difference between the two indexes is 0 bump the value.
                else if(aux[j].CompareTo(aux[i])< 0)
                {
                    arr[K] = aux[i++];
                }
                else
                {
                    arr[K] = aux[i++];
                }
            }
        }
    }
}
