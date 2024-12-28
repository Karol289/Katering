using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable
                (
                name: "Ratings",
                table => new
                {
                    RatingID = table.Column<int>(type: "int", nullable: false),
                    MealID = table.Column<int>(type: "int", nullable: false),
                    //UserID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "tinyint", nullable: true),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_Ratings", x => x.RatingID);
                    table.ForeignKey(
                        name: "FK_Ratings_Meals",
                        column: x => x.MealID,
                        principalTable: "Meals",
                        principalColumn: "MealID",
                        onDelete: ReferentialAction.Cascade,
                        onUpdate: ReferentialAction.Cascade
                        );
                    //table.ForeignKey(
                    //    name: "FK_Ratings_Users",
                    //    column: x => x.MealID,
                    //    principalTable: "",
                    //    principalColumn: "",
                    //    onDelete: ReferentialAction.SetNull,
                    //    onUpdate: ReferentialAction.Cascade
                    //    );
                    table.CheckConstraint(
                        name: "Ratings_Value_1_5",
                        sql: "VALUE IN (1,2,3,4,5)"

                    );
                }
                );
                
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Ratings");
        }
    }
}
