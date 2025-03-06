using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Models;

namespace BookManagament.Data.IRepositories;

public interface IBookRepository
{
    Task AddBook(Book book);
    Task<IEnumerable<Book>> GetAllBooks();
    Task<Book?> GetBookById(int id);
    Task UpdateBook(Book book);
    Task DeleteBook(Book book);
}
