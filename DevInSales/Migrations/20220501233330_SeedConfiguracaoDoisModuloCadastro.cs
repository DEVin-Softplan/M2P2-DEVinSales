using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class SeedConfiguracaoDoisModuloCadastro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "id", "CategoryId", "name", "suggested_price" },
                values: new object[,]
                {
                    { 1, 1, "Curso de C Sharp", 259.99m },
                    { 2, 1, "Curso de Java", 249.99m },
                    { 3, 1, "Curso de Delphi", 189.99m },
                    { 4, 1, "Curso de React", 289.99m },
                    { 5, 1, "Curso de HTML5 e CSS3", 139.99m },
                    { 6, 1, "Curso de JavaScript", 219.99m },
                    { 7, 1, "Curso de Angular", 199.99m },
                    { 8, 1, "Curso de Ruby", 319.99m },
                    { 9, 1, "Curso de Kotlin", 289.99m },
                    { 10, 1, "Curso de Python", 229.99m }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "id", "birth_date", "email", "name", "password", "ProfileId" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "romeu@lenda.com", "Romeu A Lenda", "romeu123@", 1 },
                    { 2, new DateTime(1974, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustavo_levi_ferreira@gmail.com", "Gustavo Levi Ferreira", "!romeu321", 1 },
                    { 3, new DateTime(1986, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "gustavo_levi_ferreira@gmail.com", "Gustavo Levi Ferreira", "gustavo%ferreira20", 1 },
                    { 4, new DateTime(1996, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "tomas.paulo.aragao@hotmail.com", "Tomás Paulo Aragão", "$tpa1996", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
