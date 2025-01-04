using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class CreatingViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "CREATE VIEW MealsView AS " +
                "Select Calories, Price FROM Meals"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "DROP VIEW MealsView"
                );
        }
    }
}
