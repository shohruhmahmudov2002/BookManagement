using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Models;

namespace BookManagement.App.DTOs;

public class UpdateBookDto
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublishedYear { get; set; }
    public string ISBN { get; set; }
    public Genre Genre { get; set; }
    public decimal Price { get; set; }

}
