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
    class Program
    {
        /**
         * COMMENT PROGRAM----------------------------------------------------------------------------
         * */
        static void Main(string[] args)
        {
            //Create a new droid collection and set the size of it to 100.
            IDroidCollection droidCollection = new DroidCollection(100);

            //Instantiate MergeSort
            MergeSort myMerge = new MergeSort();

            //Create Initial Data for the array.
            //-----------------------------------------------------------------------------------
           new ProtocolDroid("Quadranium","Protocol","Silver",6);
            new ProtocolDroid("Vanadium", "Protocol", "Silver", 10);
            new ProtocolDroid("Vanadium", "Protocol", "Gold", 20);

            new UtilityDroid("Quadranium", "Utility", "Gold", true, true, true);
            new UtilityDroid("Vanadium", "Utility", "Bronze", true, false, false);
            new UtilityDroid("Carbonite", "Utility", "Bronze", false, false, false);

            new JanitorDroid("Vandium", "Janitor", "Silver", true, true, true, true, true);
            new JanitorDroid("Vandium", "Janitor", "Bronze", true, false, false, false, true);
            new JanitorDroid("Quadranium", "Janitor", "Gold", false, false, false, false, false);

            new AstromechDroid("Carbonite", "Astromech", "Gold", true, true, true, true, 4);
            new AstromechDroid("Quadranium", "Astromech", "Bronze", true, false, false, false, 10);
            new AstromechDroid("Vanadium", "Astromech", "Silver", false, false, false, false, 15);
            //-----------------------------------------------------------------------------------

            

            //Create the queue necessary to store the droids.
            //MAKE A QUEUE

            //Create a user interface and pass the droidCollection into it as a dependency
            UserInterface userInterface = new UserInterface(droidCollection);

            //Display the main greeting for the program
            userInterface.DisplayGreeting();

            //Display the main menu for the program
            userInterface.DisplayMainMenu();

            //Get the choice that the user makes
            int choice = userInterface.GetMenuChoice();

            //While the choice is not equal to 3, continue to do work with the program
            while (choice != 5)
            {
                //Test which choice was made
                switch (choice)
                {
                    //Choose to create a droid
                    case 1:
                        userInterface.CreateDroid();
                        break;

                    //Choose to Print the droid
                    case 2:
                        userInterface.PrintDroidList();
                        break;
                    //Sort by Total Cost
                    case 3:
                        
                        myMerge.Sort(droidCollection[],0,9);
                        break;
                    //Sort by Type
                    case 4:

                        break;
                }
                //Re-display the menu, and re-prompt for the choice
                userInterface.DisplayMainMenu();
                choice = userInterface.GetMenuChoice();
            }


        }
    }
}
