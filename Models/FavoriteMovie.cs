using System;

namespace Final_Project.Models
{
    public class FavoriteMovie
    {
        public int Id { get; set; }
        public string MemberName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Rating { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime Published { get; set; }
        public string Runtime { get; set; } = string.Empty;
    }
}