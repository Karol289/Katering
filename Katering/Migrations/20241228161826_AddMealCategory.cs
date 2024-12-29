using Katering.Data.Food;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddMealCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealCategories",
                columns: table => new
                {
                    MealCategoryId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_MealCategories", x => x.MealCategoryId);          
                });


             Seed(migrationBuilder);
        }


        protected void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "MealCategories",
            columnTypes: new string[] { "nvarchar(40)"},
            columns: new[] { "Name" },
            values: new object[,]
            {
                     { "Breakfast" },
                     { "Lunch" },
                     { "Dinner" },
                     { "Snack" },
                     { "Dessert" }
            });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MealCategories");
        }
    }
}
