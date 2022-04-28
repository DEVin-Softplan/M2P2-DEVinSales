using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class add_state_squad2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "id", "initials", "name" },
                values: new object[,]
                {
                    { 11, "RO", "Rondônia" },
                    { 12, "AC", "Acre" },
                    { 13, "AM", "Amazonas" },
                    { 14, "RR", "Roraima" },
                    { 15, "PA", "Pará" },
                    { 16, "AP", "Amapá" },
                    { 17, "TO", "Tocantins" },
                    { 21, "MA", "Maranhão" },
                    { 22, "PI", "Piauí" },
                    { 23, "CE", "Ceará" },
                    { 24, "RN", "Rio Grande do Norte" },
                    { 25, "PB", "Paraíba" },
                    { 26, "PE", "Pernambuco" },
                    { 27, "AL", "Alagoas" },
                    { 28, "SE", "Sergipe" },
                    { 29, "BA", "Bahia" },
                    { 31, "MG", "Minas Gerais" },
                    { 32, "ES", "Espirito Santo" },
                    { 33, "RJ", "Rio de Janeiro" },
                    { 35, "SP", "São Paulo" },
                    { 41, "PR", "Paraná" },
                    { 42, "SC", "Santa Catarina" },
                    { 43, "RS", "Rio Grande do Sul" },
                    { 50, "MS", "Mato Grosso do Sul" },
                    { 51, "MT", "Mato Grosso" },
                    { 52, "GO", "Goiás" },
                    { 53, "DF", "Distrito Federal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
