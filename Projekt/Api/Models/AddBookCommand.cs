namespace Api.Models;

public class AddBookCommand
{
    public string Title { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
    public string Author { get; set; } = string.Empty;
}
