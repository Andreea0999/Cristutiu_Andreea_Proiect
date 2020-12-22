using Microsoft.EntityFrameworkCore.Migrations;

namespace Cristutiu_Andreea_Proiect.Migrations
{
    public partial class TotalOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "OrderPrice",
                table: "Order",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderPrice",
                table: "Order");
        }
    }
}
