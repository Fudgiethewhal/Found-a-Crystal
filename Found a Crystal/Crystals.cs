namespace Found_a_Crystal;

public class Crystals(string? classification, string? description, string? color) : ICrystal
{
    public string Classification { get; set; } 
    public string Description { get; set; }
    public string Color { get; set; }
    
}