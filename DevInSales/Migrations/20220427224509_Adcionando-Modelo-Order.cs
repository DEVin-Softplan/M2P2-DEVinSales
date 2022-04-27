using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class AdcionandoModeloOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "unit_price",
                table: "order_product",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    seller_id = table.Column<int>(type: "int", nullable: false),
                    date_order = table.Column<DateTime>(type: "datetime2", nullable: false),
                    shipping_company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shipping_company_price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.AlterColumn<decimal>(
                name: "unit_price",
                table: "order_product",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
