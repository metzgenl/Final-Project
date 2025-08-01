using System;

namespace Final_Project.Models;

public class Hobby
{
    public int ID { get; set; }
    public string HobbyName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string SkillLevel { get; set; } = null!;
    public int EnjoymentRating { get; set; }

}
