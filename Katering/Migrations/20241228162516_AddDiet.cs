using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddDiet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diets",
                table => new
                {
                    DietId = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_Diets", x => x.DietId);
                }
                );

            Seed(migrationBuilder);
        }

        protected void Seed(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "Diets",
            columnTypes: new string[] { "nvarchar(50)" },
            columns: new[] { "Name" },
            values: new object[,]
            {
                { "Standard" },
                { "Low Fat" },
                { "High Protein" },
                { "Balanced" },
                { "Vegetarian" },
                { "Vegan" },
                { "Gluten-Free" },
                { "Pescatarian" }
            });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Diets");
        }
    }
}
