using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManagament.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genres",
                table: "book",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "Id",
                keyValue: 1,
                column: "Genres",
                value: "Fiction");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Genres",
                table: "book",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "book",
                keyColumn: "Id",
                keyValue: 1,
                column: "Genres",
                value: 0);
        }
    }
}
