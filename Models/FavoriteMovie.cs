namespace FINAL-PROJECT.Models;

public class FavoriteBook
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Rating { get; set; }
    public int Genre { get; set; }
    public DateTime Published { get; set; }
    public string Runtime { get; set; }
}
