using Microsoft.EntityFrameworkCore.Migrations;

namespace Cristutiu_Andreea_Proiect.Migrations
{
    public partial class AddPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTotal",
                table: "OrderProduct");

            migrationBuilder.DropColumn(
                name: "CustomerAdress",
                table: "Customer");

            migrationBuilder.AddColumn<int>(
                name: "PlatformID",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerEmail",
                table: "Customer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(nullable: true),
                    PlatformAdress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_PlatformID",
                table: "Product",
                column: "PlatformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Platform_PlatformID",
                table: "Product",
                column: "PlatformID",
                principalTable: "Platform",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Platform_PlatformID",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Platform");

            migrationBuilder.DropIndex(
                name: "IX_Product_PlatformID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PlatformID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CustomerEmail",
                table: "Customer");

            migrationBuilder.AddColumn<decimal>(
                name: "ProductTotal",
                table: "OrderProduct",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CustomerAdress",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
