using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagament.Data.Migrations
{
    /// <inheritdoc />
    public partial class ISBNUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_book_ISBN",
                table: "book",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_book_ISBN",
                table: "book");
        }
    }
}
