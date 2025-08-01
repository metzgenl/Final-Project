using System;

namespace Final_Project.Models;

public class FavoriteFood
{
    public int Id { get; set; }
    public string Ingredients { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Calories { get; set; }
    public string OriginCountry { get; set; } = null!;
    public bool IsSpicy { get; set; }
}