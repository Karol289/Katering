using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class AddPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<double>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<int>(type:"int", nullable: false),
                    Date = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_Payments", x => x.PaymentID);
                }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Payments");
        }
    }
}
