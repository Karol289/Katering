using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Katering.Migrations
{
    /// <inheritdoc />
    public partial class dane : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            // Wstawianie przykładowych danych do tabeli Orders
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "PaymentId", "Status", "Date", "Discount", "UserId"},
                values: new object[,]
                {
                    { null, 1, DateTime.Now, 10.5,1 },
                    { null, 2, DateTime.Now.AddDays(-1), 5.0,1 },
                    { null, 3, DateTime.Now.AddDays(-2), 0.0,1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Orders WHERE OrderId IN (1, 2, 3)");
        }
    }
}
