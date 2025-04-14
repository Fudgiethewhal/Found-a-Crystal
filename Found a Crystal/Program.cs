using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Found_a_Crystal;

class Program
{
    //Defines a private, unmodifiable list of strings representing crystal types.
    private static readonly List<string> CrystalTypes = new List<string>()
    {
        "Cubic",
        "Tetragonal",
        "Orthorhombic",
        "Monoclinic",
        "Triclinic",
        "Rhombohedral",
        "Hexagonal",
        "Not Sure?"
    };
    static void Main(string[] args)
    {
        //Creates a dictionary where each key is a location(string) and the 
        //value is a list of Crystal objects found at the location.
        Dictionary<string, List<Crystals>> crystalsCollection = new Dictionary<string, List<Crystals>>();
        CrystalManager crystalManager = new CrystalManager();

        while (true)
        {
            Console.WriteLine("\nCrystal Collection Tracker");
            Console.WriteLine("1. Add Crystals");
            Console.WriteLine("2. View Collection");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            //This will show the reader the input from the console.
            string choice = Console.ReadLine();
            
            //this is where the reader will select their input.
            switch (choice)
            {
                case "1":
                    AddCrystals(crystalsCollection);
                    break;
                case "2":
                    ViewCollection(crystalsCollection);
                    break;
                case "3":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Enter your choice: ");
                    break;
            }
        }
    }
    
    //A method for adding crystals to the collection.
    static void AddCrystals(Dictionary<string, List<Crystals>> collection)
    {
        //Prompts the user for a location where the crystal was found.
        Console.WriteLine("Enter Location:");
        string location = Console.ReadLine();
        
        //displays a numbered list of crystal types
        Console.WriteLine("Enter crystal type: ");
        for (int i = 0; i < CrystalTypes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {CrystalTypes[i]}");
        }

        //Reads and validates the user's choice with int.TryParse
        Console.Write("Choose option: ");
        if (!int.TryParse(Console.ReadLine(), out int choice) || choice <= 0 || choice > CrystalTypes.Count)
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        //This is where the type of crystal is selected
        string type = CrystalTypes[choice - 1];
        
        //the description is for the user to add their crystal info.
        Console.WriteLine("Enter Classification: ");
        string classification = Console.ReadLine();
        
        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter crystal color: ");
        string color = Console.ReadLine();
        
        //creates a new crystal object using classification and description.
        Crystals crystal = new Crystals(classification, description, color);

        //Checks if the location already exists in the dictionary.
        if (!collection.ContainsKey(location))
        {
            //.Add will add a new location if doesn't exist.
            collection.Add(location, new List<Crystals>());
        }
        //Adds the new crystal to the list at the specified location
        collection[location].Add(crystal);
        //This will show that the crystal has been added.
        Console.WriteLine($"Added crystal to collection with a description of {description}.");
    }

    static void ViewCollection(Dictionary<string, List<Crystals>> collection)
    {
        //this is where the crystals are stored
        Console.WriteLine("\nCrystal Collection:");
        if (collection.Count == 0)
        {
            //this is where no crystals have been added
            Console.WriteLine("No crystals collected yet!");
            return;
        }

        foreach (var location in collection)
        {
            Console.WriteLine($"\nLocation: {location.Key}");
            foreach (var crystal in location.Value)
            {
                Console.WriteLine($"  - Type: {crystal.Classification}, Description: {crystal.Description}, Color: {crystal.Color}");
            }
        }
    }
}
