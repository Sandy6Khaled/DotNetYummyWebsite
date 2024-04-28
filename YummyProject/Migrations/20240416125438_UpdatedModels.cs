using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YummyProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "strDrinkAlternate",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "strDescription",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "strType",
                table: "Ingredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "strDrinkAlternate",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "strDescription",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "strType",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
