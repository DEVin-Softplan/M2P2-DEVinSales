using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class SeedConfiguracaoUmModuloCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "id", "name", "slug" },
                values: new object[] { 1, "Categoria Padrão", "categoria-padrao" });

            migrationBuilder.InsertData(
                table: "Profile",
                columns: new[] { "id", "name" },
                values: new object[] { 1, "Cliente" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Profile",
                keyColumn: "id",
                keyValue: 1);
        }
    }
}
