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
                    MealID = table.Column<int>(type: "int", nullable: false)
                     .Annotation("SqlServer:Identity", "1, 1"),
                    DietTypeID = table.Column<int>(type: "int", nullable: true),
                    MealCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "decimal(5)", nullable: true),
                    Price = table.Column<double>(type: "decimal(10,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealID);
                    table.ForeignKey(
                        name: "FK_Meals_DietTypes",
                        column: x => x.DietTypeID,
                        principalTable: "Diets",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.SetNull,
                        onUpdate: ReferentialAction.Cascade
                        );
                    table.ForeignKey(
                        name: "FK_Meals_MealCategories",
                        column: x => x.MealCategoryID,
                        principalTable: "MealCategories",
                        principalColumn: "MealCategoryID",
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
