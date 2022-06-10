using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class AdicionandoTipoDeProfile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_Product_OrderProductId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderProductId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Profile",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Order_Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "shipping_Company",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "delivery_Date",
                table: "Delivery",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_OrderId",
                table: "Order_Product",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Product_ProductId",
                table: "Order_Product",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_Order_OrderId",
                table: "Order_Product",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Product_Product_ProductId",
                table: "Order_Product",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_Order_OrderId",
                table: "Order_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Product_Product_ProductId",
                table: "Order_Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_Product_OrderId",
                table: "Order_Product");

            migrationBuilder.DropIndex(
                name: "IX_Order_Product_ProductId",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Profile");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Order_Product");

            migrationBuilder.DropColumn(
                name: "shipping_Company",
                table: "Order");

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "delivery_Date",
                table: "Delivery",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderProductId",
                table: "Order",
                column: "OrderProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_Product_OrderProductId",
                table: "Order",
                column: "OrderProductId",
                principalTable: "Order_Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId",
                principalTable: "Order_Product",
                principalColumn: "Id");
        }
    }
}
