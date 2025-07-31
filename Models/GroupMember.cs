using System;

namespace Final_Project.Models;
public class GroupMember
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public DateTime Birthdate { get; set; }
    public string CollegeProgram { get; set; } = null!;
    public string YearInProgram { get; set; } = null!;
    public string Email { get; set; } = null!;
}