using System.Reflection;
using System.Text.Json.Serialization;
using BookManagament.Data.Data;
using BookManagament.Data.IRepositories;
using BookManagament.Data.Repositories;
using BookManagement.Api.Examples;
using BookManagement.App.IServices;
using BookManagement.App.Services;
using BookManagement.App.Validators;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;

namespace BookManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddValidatorsFromAssemblyContaining<CreateBookValidation>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateBookValidation>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<EnumSchemaFilter>();
                c.ExampleFilters();
            });

            builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
            builder.Services.AddDbContext<BookContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(new AuditInterceptor());
            });

            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
