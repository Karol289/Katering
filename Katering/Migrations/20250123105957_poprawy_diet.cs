using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class poprawy_diet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingID",
                table: "Ratings",
                newName: "RatingId");

            migrationBuilder.RenameColumn(
                name: "DietID",
                table: "Diets",
                newName: "DietId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RatingId",
                table: "Ratings",
                newName: "RatingID");

            migrationBuilder.RenameColumn(
                name: "DietId",
                table: "Diets",
                newName: "DietID");
        }
    }
}
