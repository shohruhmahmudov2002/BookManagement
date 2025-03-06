using BookManagament.Data.Models;
using BookManagement.App.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace BookManagement.Api.Examples;

public class CreateBookExample : IExamplesProvider<CreateBookDto>
{
    public CreateBookDto GetExamples()
    {
        return new CreateBookDto
        {
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            PublishedYear = 1937,
            ISBN = "9780261102217",
            Genre = Genre.Fiction,
            Price = 9.99m
        };
    }
}

public class UpdateBookExample : IExamplesProvider<UpdateBookDto>
{
    public UpdateBookDto GetExamples()
    {
        return new UpdateBookDto
        {
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            PublishedYear = 1937,
            ISBN = "9780261102217",
            Genre = Genre.Fiction,
            Price = 9.99m
        };
    }
}
