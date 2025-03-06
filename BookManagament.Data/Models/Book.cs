using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BookManagament.Data.Models;

public class Book : IAuditable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
    public string ISBN { get; set; }
    public Genre Genres { get; set; }
    public decimal Price { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public enum Genre
{
    [EnumMember(Value = "Fiction")]
    Fiction = 1,
    [EnumMember(Value = "Non-Fiction")]
    NonFiction,
    [EnumMember(Value = "Biography")]
    Biography,
    [EnumMember(Value = "Science")]
    Science,
    [EnumMember(Value = "History")]
    History
}
    