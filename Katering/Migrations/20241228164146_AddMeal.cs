using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddMeal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    MealId = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                    DietTypeId = table.Column<int>(type: "int", nullable: true),
                    MealCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "decimal(5)", nullable: true),
                    Price = table.Column<double>(type: "decimal(10,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_DietTypes_DietId",
                        column: x => x.DietTypeId,
                        principalTable: "Diets",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.SetNull,
                        onUpdate: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_Meals_MealCategories_MealCategoryId",
                        column: x => x.MealCategoryId,
                        principalTable: "MealCategories",
                        principalColumn: "MealCategoryId",
                        onDelete: ReferentialAction.SetNull,
                        onUpdate: ReferentialAction.Cascade
                        );
                }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Meals");
        }
    }
}
