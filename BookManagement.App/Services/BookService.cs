using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.IRepositories;
using BookManagament.Data.Models;
using BookManagement.App.DTOs;
using BookManagement.App.IServices;

namespace BookManagement.App.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task AddBook(CreateBookDto book)
    {
        await _bookRepository.AddBook(new Book
        {
            Title = book.Title,
            Author = book.Author,
            PublishedYear = book.PublishedYear,
            ISBN = book.ISBN,
            Genres = book.Genre,
            Price = book.Price
        });
    }

    public async Task<IEnumerable<BookDto>> GetAllBooks()
    {
        var books = await _bookRepository.GetAllBooks();

        return books.Select(book => new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedYear = book.PublishedYear,
            ISBN = book.ISBN,
            Genre = book.Genres,
            Price = book.Price
        });
    }

    public async Task<BookDto?> GetBookById(int id)
    {
        var book = await _bookRepository.GetBookById(id);

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedYear = book.PublishedYear,
            ISBN = book.ISBN,
            Genre = book.Genres,
            Price = book.Price
        };
    }

    public async Task UpdateBook(int id, UpdateBookDto bookDto)
    {
        var book = await _bookRepository.GetBookById(id);

        book.Title = bookDto.Title;
        book.Author = bookDto.Author;
        book.PublishedYear = bookDto.PublishedYear;
        book.ISBN = bookDto.ISBN;
        book.Genres = bookDto.Genre;
        book.Price = bookDto.Price;

        await _bookRepository.UpdateBook(book);
    }

    public async Task DeleteBook(int id)
    {
        var book = await _bookRepository.GetBookById(id);
        await _bookRepository.DeleteBook(book);
    }
}
