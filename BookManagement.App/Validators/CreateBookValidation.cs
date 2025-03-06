using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagament.Data.Data;
using BookManagement.App.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.App.Validators;

public class CreateBookValidation : AbstractValidator<CreateBookDto>
{
    public CreateBookValidation()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required")
            .MaximumLength(200)
            .WithMessage("Title should not be longer than 200 characters");

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Author is required")
            .MaximumLength(100)
            .WithMessage("Author should not be longer than 100 characters");

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required")
            .Length(13)
            .WithMessage("ISBN should be 13 characters")
            .Matches("^[0-9]*$")
            .WithMessage("ISBN should be numeric");

        RuleFor(x => x.Genre)
            .NotEmpty()
            .WithMessage("Genre is required")
            .IsInEnum()
            .WithMessage("Invalid genre type");

        RuleFor(x => x.PublishedYear)
            .NotEmpty()
            .WithMessage("Published year is required")
            .InclusiveBetween(1900, DateTime.Now.Year)
            .WithMessage("Published year should be between 1900 and current year");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Price is required")
            .GreaterThan(0)
            .WithMessage("Price should be greater than 0");
    }
}

