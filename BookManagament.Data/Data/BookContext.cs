using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagament.Data.Data;

public class BookContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    
    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    public BookContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
