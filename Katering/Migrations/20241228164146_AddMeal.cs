using Katering.Data.Food;
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
                    DietId = table.Column<int>(type: "int", nullable: true),
                    MealCategoryId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calories = table.Column<double>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.MealId);
                    table.ForeignKey(
                        name: "FK_Meals_DietTypes_DietId",
                        column: x => x.DietId,
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


            Seed(migrationBuilder);

        }

        private void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Meals",
                columnTypes: new string[] { "DietId", "MealCategoryId", "Name", "Calories", "Price", "Description" },
                columns: new[] { "DietId", "MealCategoryId", "Name", "Calories", "Price", "Description" },
                values: new object[,]
                {
                     { 1, 1, "Vegan Pancakes", 300, 5.99, "Delicious vegan pancakes with syrup" },
                     { 2, 2, "Chicken Salad", 450, 7.99, "Healthy chicken salad with dressing" },
                     { 3, 3, "Grilled Salmon", 600, 12.99, "Grilled salmon with vegetables" },
                     { 1, 4, "Fruit Salad", 150, 3.99, "Fresh seasonal fruit" },
                     { 4, 5, "Chocolate Cake", 500, 4.99, "Decadent chocolate cake" },
                     { 3, 2, "Steak and Eggs", 700, 15.99, "Steak served with eggs and avocado" },
                     { 2, 3, "Turkey Sandwich", 350, 6.99, "Low-fat turkey sandwich on whole grain" },
                     { 1, 1, "Vegan Waffles", 400, 6.49, "Crispy vegan waffles with berries" },
                     { 4, 2, "Quinoa Salad", 450, 7.49, "Quinoa with vegetables and a lemon dressing" },
                     { 3, 4, "Avocado Toast", 350, 5.99, "Toasted bread with smashed avocado and herbs" },
                     { 1, 3, "Vegan Tacos", 250, 4.99, "Soft tortillas with spiced beans and vegetables" },
                     { 4, 1, "Oatmeal with Berries", 250, 4.49, "Healthy oatmeal topped with mixed berries" },
                     { 2, 5, "Apple Pie", 300, 3.49, "Classic apple pie with a flaky crust" },
                     { 1, 3, "Vegan Stir-Fry", 400, 8.99, "Tofu stir-fry with vegetables and soy sauce" },
                     { 3, 4, "Cheese Omelette", 500, 7.49, "Egg omelette with cheese and herbs" },
                     { 4, 2, "Veggie Wrap", 350, 5.49, "Whole grain wrap filled with vegetables" },
                     { 2, 1, "Egg Muffins", 250, 4.99, "Baked egg muffins with spinach and cheese" },
                     { 3, 5, "Keto Cheesecake", 600, 8.99, "Keto-friendly cheesecake with almond crust" },
                     { 1, 3, "Vegan Chili", 350, 6.99, "Spicy vegan chili with beans and vegetables" },
                     { 2, 2, "Grilled Chicken Wrap", 400, 7.99, "Grilled chicken with veggies in a whole grain wrap" }
                });
        }



        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Meals");
        }
    }
}
