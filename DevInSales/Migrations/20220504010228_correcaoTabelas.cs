using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class correcaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderProductId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_price = table.Column<decimal>(type: "decimal", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ShippingCompanyId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatePrice_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    date_order = table.Column<DateTime>(type: "date", nullable: false),
                    shipping_company_price = table.Column<decimal>(type: "decimal", nullable: false),
                    OrderProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.id);
                    table.ForeignKey(
                        name: "FK_Order_Order_Product_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "Order_Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_User_SellerId",
                        column: x => x.SellerId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingCompany",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatePriceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingCompany_StatePrice_StatePriceId",
                        column: x => x.StatePriceId,
                        principalTable: "StatePrice",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    delivery_Forecast = table.Column<DateTime>(type: "date", nullable: false),
                    delivery_Date = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.id);
                    table.ForeignKey(
                        name: "FK_Delivery_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Delivery_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CityPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ShippingCompanyId = table.Column<int>(type: "int", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityPrice_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityPrice_ShippingCompany_ShippingCompanyId",
                        column: x => x.ShippingCompanyId,
                        principalTable: "ShippingCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPrice_CityId",
                table: "CityPrice",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPrice_ShippingCompanyId",
                table: "CityPrice",
                column: "ShippingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_AddressId",
                table: "Delivery",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivery_OrderId",
                table: "Delivery",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderProductId",
                table: "Order",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SellerId",
                table: "Order",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCompany_StatePriceId",
                table: "ShippingCompany",
                column: "StatePriceId");

            migrationBuilder.CreateIndex(
                name: "IX_StatePrice_StateId",
                table: "StatePrice",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product",
                column: "OrderProductId",
                principalTable: "Order_Product",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Order_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "CityPrice");

            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropTable(
                name: "ShippingCompany");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "StatePrice");

            migrationBuilder.DropTable(
                name: "Order_Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_OrderProductId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "OrderProductId",
                table: "Product");
        }
    }
}
