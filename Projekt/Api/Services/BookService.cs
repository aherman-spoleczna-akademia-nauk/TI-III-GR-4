using Api.Models;

namespace Api.Services;

public class BookService
{
    private List<Book> _books = new List<Book>();

    public BookService()
    {
        _books.Add(new Book
        {
            Title = "Władca Pierścieni",
            ReleaseYear = 1954,
            Author = "J.R.R. Tolkien"
        });

        _books.Add(new Book
        {
            Title = "Ojciec Chrzestny",
            ReleaseYear = 1935,
            Author = "Mario Puzo"
        });
    }

    public List<Book> GetBooks(string? title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return _books;

        return _books.Where(b => b.Title.ToLower().StartsWith(title.ToLower())).ToList();
    }


    public ApiResult AddNewBook(AddBookCommand command)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(command.Title))
            errors.Add("Brak tytułu");

        if (string.IsNullOrWhiteSpace(command.Author))
            errors.Add("Brak autora");

        if (command.ReleaseYear <= 0)
            errors.Add("Nieprawidłowa data wydania");

        if (errors.Any())
            return new ApiResult { Success = false, Error = string.Join(", ", errors) };


        var newBook = new Book
        {
            Title = command.Title,
            ReleaseYear = command.ReleaseYear,
            Author = command.Author
        };

        _books.Add(newBook);

        return new ApiResult
        {
            Success = true,
            Data = $"Książka dodana pomyślnie. Id: {newBook.BookId}"
        };
    }
}
