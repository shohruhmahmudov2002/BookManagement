using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagament.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedConfigurationISBN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_book_ISBN",
                table: "book");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_book_ISBN",
                table: "book",
                column: "ISBN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_book_ISBN",
                table: "book");

            migrationBuilder.CreateIndex(
                name: "IX_book_ISBN",
                table: "book",
                column: "ISBN",
                unique: true);
        }
    }
}
