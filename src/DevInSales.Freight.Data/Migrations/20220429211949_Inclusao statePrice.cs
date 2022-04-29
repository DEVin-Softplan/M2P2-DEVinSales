using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Freight.Data.Migrations
{
    public partial class InclusaostatePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initial = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "state_price",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ShippingCompanyId = table.Column<int>(type: "int", nullable: false),
                    BasePreco = table.Column<decimal>(type: "decimal(16,2)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state_price", x => x.Id);
                    table.ForeignKey(
                        name: "FK_state_price_shipping_company_ShippingCompanyId",
                        column: x => x.ShippingCompanyId,
                        principalTable: "shipping_company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_state_price_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_state_price_ShippingCompanyId",
                table: "state_price",
                column: "ShippingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_state_price_StateId",
                table: "state_price",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "state_price");

            migrationBuilder.DropTable(
                name: "state");
        }
    }
}
