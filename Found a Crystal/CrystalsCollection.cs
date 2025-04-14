using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Found_a_Crystal;

public class CrystalsCollection 
{
    //returns a crystal object created based on user input
    public static Crystals CreateFromUserInput()
    {
        Console.WriteLine("Choose a classification: ");
        //loops through each type in the CrystalTypes list
        for (int i = 0; i < CrystalManager.Count; i++)
        {
            //Displays each crystal type as a numbered option starting from 1.
            Console.WriteLine($"{i + 1}. {CrystalManager[i]}");
        }

        //User will inout their response
        Console.Write("Enter your choice (1-8: ");
        string input = Console.ReadLine(); //will read the user's input as a string

        //tries to convert the input string into an integer, if successful
        //the integer is stored in choice
        //returns false if the input is invalid
        //ensures the choice is within the valid range of crystal types
        if (int.TryParse(input, out int choice) && choice >= 1 && choice <= CrystalTypes.Count)
        {
            //gets the selected crystal type from the list
            string selectedClassification = Crystals[choice - 1];
            Console.WriteLine($"You selected: {selectedClassification}"); //will display on the console.

            //will ask the user to describe crystal
            Console.Write("Enter your description of the crystal: ");
            string description = Console.ReadLine();

            //creates and returns a new crystal object using 
            //the selected type and user-provided description
            Console.WriteLine($"Enter the color of the crystal:");
            string color = Console.ReadLine();

            return new Crystals(
            {
                Classification = selectedClassification,
                Description = description,
                Color = color
            };
        }
        else //This will occur when the input is invalid
        {
            Console.WriteLine("Invalid choice. No crystal found.");
            return null;
        }
    }
}