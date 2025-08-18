using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Found_a_Crystal
{
    public class Crystals
    {
        public string Classification { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }

    public static class CrystalManager()
    {
        public static List<string> CrystalTypes = new List<string>
        {
            "Quartz", "Amethyst", "Citrine", "Topaz", "Emerald", "Ruby", "Sapphire", "Diamond"
        };
    }

    public class CrystalsCollection
    {
        public static Crystals CreateFromUserInput()
        {
            Console.WriteLine("Choose a classification:");
            for (int i = 0; i < CrystalManager.CrystalTypes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {CrystalManager.CrystalTypes[i]}");
            }

            Console.Write("Enter your choice (1-8): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= CrystalManager.CrystalTypes.Count)
            {
                string selectedClassification = CrystalManager.CrystalTypes[choice - 1];
                Console.WriteLine($"You selected: {selectedClassification}");

                Console.Write("Enter your description of the crystal: ");
                string description = Console.ReadLine();

                Console.Write("Enter the color of the crystal: ");
                string color = Console.ReadLine();

                return new Crystals
                {
                    Classification = selectedClassification,
                    Description = description,
                    Color = color
                };
            }
            else
            {
                Console.WriteLine("Invalid choice. No crystal found.");
                return null;
            }
        }
    }
}