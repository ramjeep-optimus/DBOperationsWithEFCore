using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBOperationsWithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class updatedType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { 1, "Indian INR", "INR" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
