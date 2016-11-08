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
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;

        


        //Private variable to hold the length of the Collection
        private int lengthOfCollection;

        //Create the four Stacks for the separation of the initial array
            //---------------------------------------------------
            GenericStack<object> protocolStack = new GenericStack<object>();
            GenericStack<object> utilityStack = new GenericStack<object>();
            GenericStack<object> janitorStack = new GenericStack<object>();
            GenericStack<object> astromechStack = new GenericStack<object>();      
            //---------------------------------------------------

            //Create a Queue to hold the organized Droids.
            GenericQueue<object> organizedQueue = new GenericQueue<object>();

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }
        /// <summary>
        /// Similar to hash table creation
        /// </summary>
        /// <param name="Data"></param>
        public static void BucketSort(ref int[] Data)
        {
            //values used to store the min and max, and corresponding index.
            int minValue = Data[0];
            int maxValue = Data[0];

            //Read through array to find the Min and Max value.
            for(int i=1;i<Data.Length;i++)
            {
                if(Data[i]>maxValue)
                {
                    //replace the old with the new
                    maxValue = Data[i];
                }
                if(Data[i]<minValue)
                {
                    //replace the old with the new
                    minValue = Data[i];
                }
            }
            //Instiate a new integer link list with the range of (max-min)+1
            List<int>[] bucket = new List<int>[maxValue - minValue - 1];

            //loop through and create a new integer link list at every index.
            for (int i = 0; i < bucket.Length;i++)
            {
                bucket[i]=new List<int>();
            }

            for(int i=0; i<bucket.Length;i++)
            {
                bucket[Data[i] - minValue].Add(Data[i]);
            }
            int k=0;
            for(int i=0; i<bucket.Length;i++)
            {
                if(bucket[i].Count() > 0)
                {
                    for(int j=0;j<bucket.Length; j++)
                    {
                        Data[k] = bucket[i][j];
                        k++;
                    }
                }
            }
        }
        /**
         * Adjust bucket sort method to accomodate differences in program versus website code sequence.
         * */

        //method used to determine the droid's type to send it to the correct stack.
        public void DetermineDroidType(IDroidCollection[] Coll)
        {
            for(int i=0;i<Coll.Length;i++)
            {
                if(Coll[i].GetType()==typeof(AstromechDroid))
                {
                    protocolStack.AddToFront(Coll[i]);
                }
                else if (Coll[i].GetType() == typeof(JanitorDroid))
                {
                    utilityStack.AddToFront(Coll[i]);
                }
                else if (Coll[i].GetType() == typeof(UtilityDroid))
                {
                    janitorStack.AddToFront(Coll[i]);
                }
                else if (Coll[i].GetType() == typeof(ProtocolDroid))
                {
                    astromechStack.AddToFront(Coll[i]);
                }
            }
        }
        /// <summary>
        /// Enqueues all the droids one type at a time by checking to see if the current
        /// type being added has 0 left. (One call per stack)
        /// </summary>
        public void EnqueueByType(GenericStack<object> DroidStack,GenericQueue<object> Queue )
        {
            //loop used to Empty the passed DroidStack into the Queue.
            for (int i = 0; i < DroidStack.Size;i++)
            {
                //variable used to index the Queue to ensure proper indexing of the stack and queuee
                int j = 0;
                //Loop ensuring that the index being saved doesn't already contain a droid.
                while(Queue[j]!=null)
                {
                    j++;
                }
                if(Queue[j]==null)
                {
                    //Queue[j] = DroidStack[i];
                    Queue.AddToBack(DroidStack[i]);
                }
            }

        }
    }
}
