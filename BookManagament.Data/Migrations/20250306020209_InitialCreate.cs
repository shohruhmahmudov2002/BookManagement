using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BookManagament.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PublishedYear = table.Column<int>(type: "integer", nullable: false),
                    ISBN = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    Genres = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "book",
                columns: new[] { "Id", "Author", "Genres", "ISBN", "Price", "PublishedYear", "Title" },
                values: new object[] { 1, "F. Scott Fitzgerald", 0, "9780743273565", 9.99m, 1925, "The Great Gatsby" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book");
        }
    }
}
