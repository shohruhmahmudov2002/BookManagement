using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManagament.Data.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("book");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        builder.Property(b => b.Title).IsRequired().HasMaxLength(200);
        
        builder.Property(b => b.Author).IsRequired().HasMaxLength(100);
        
        builder.Property(b => b.ISBN).IsRequired().HasMaxLength(13);
        builder.HasIndex(b => b.ISBN).IsUnique();

        builder.Property(b => b.Price).IsRequired();

        builder.Property(b => b.Genres).IsRequired().HasConversion<string>();

        builder.HasData(
            new Book()
            {
                Id = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                PublishedYear = 1925,
                ISBN = "9780743273565",
                Genres = Genre.Fiction,
                Price = 9.99m
            }
        );
    }
}
