using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddMealAndSubscriptionOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealsOrder",
                columns: table => new
                {
                    MealOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealsOrder", x => x.MealOrderId);
                    table.ForeignKey(
                        name: "FK_MealsOrder_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId");
                    table.ForeignKey(
                        name: "FK_MealsOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "OrdersOrder",
                columns: table => new
                {
                    SubscriptionOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersOrder", x => x.SubscriptionOrderId);
                    table.ForeignKey(
                        name: "FK_OrdersOrder_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "MealId");
                    table.ForeignKey(
                        name: "FK_OrdersOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealsOrder_MealId",
                table: "MealsOrder",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealsOrder_OrderId",
                table: "MealsOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersOrder_MealId",
                table: "OrdersOrder",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersOrder_OrderId",
                table: "OrdersOrder",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealsOrder");

            migrationBuilder.DropTable(
                name: "OrdersOrder");
        }
    }
}
