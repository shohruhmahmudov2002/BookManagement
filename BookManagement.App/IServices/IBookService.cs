using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.App.DTOs;

namespace BookManagement.App.IServices;

public interface IBookService
{
    Task AddBook(CreateBookDto book);
    Task<IEnumerable<BookDto>> GetAllBooks();
    Task<BookDto?> GetBookById(int id);
    Task UpdateBook(int id, UpdateBookDto book);
    Task DeleteBook(int id);
}
