using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nom",
                table: "products",
                newName: "titre");

            migrationBuilder.AddColumn<int>(
                name: "compare_prix",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "compare_prix",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "titre",
                table: "products",
                newName: "nom");
        }
    }
}
