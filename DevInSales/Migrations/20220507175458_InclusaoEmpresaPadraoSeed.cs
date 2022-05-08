using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class InclusaoEmpresaPadraoSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShippingCompany",
                columns: new[] { "id", "Name" },
                values: new object[] { 4, "Empresa Padrão" });

            migrationBuilder.InsertData(
                table: "CityPrice",
                columns: new[] { "id", "base_price", "CityId", "ShippingCompanyId" },
                values: new object[,]
                {
                    { 10, 5m, 1, 4 },
                    { 11, 6m, 2, 4 },
                    { 12, 7m, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "StatePrice",
                columns: new[] { "id", "base_price", "ShippingCompanyId", "StateId" },
                values: new object[,]
                {
                    { 10, 5m, 4, 11 },
                    { 11, 6m, 4, 22 },
                    { 12, 7m, 4, 33 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CityPrice",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "CityPrice",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "CityPrice",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "StatePrice",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "StatePrice",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "StatePrice",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ShippingCompany",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
