using Microsoft.EntityFrameworkCore.Migrations;

namespace Cristutiu_Andreea_Proiect.Migrations
{
    public partial class ProductTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ProductTotal",
                table: "OrderProduct",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTotal",
                table: "OrderProduct");
        }
    }
}
