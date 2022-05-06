using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class ajustenometabelastateprice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StatePrice",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "BasePrice",
                table: "StatePrice",
                newName: "base_preco");

            migrationBuilder.AlterColumn<decimal>(
                name: "base_preco",
                table: "StatePrice",
                type: "decimal",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "StatePrice",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "base_preco",
                table: "StatePrice",
                newName: "BasePrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "StatePrice",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal");
        }
    }
}
