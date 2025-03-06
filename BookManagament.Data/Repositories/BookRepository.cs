using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Data;
using BookManagament.Data.IRepositories;
using BookManagament.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagament.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookContext _context;
    public BookRepository(BookContext context)
    {
        _context = context;
    }

    public async Task AddBook(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _context.Books.
            OrderByDescending(b => b.Title).ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _context.Books.
            FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task UpdateBook(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
    }
}
