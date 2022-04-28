using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevInSales.Migrations
{
    public partial class IncluseStatesSquad_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_City_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_State_Id",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "State",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Initials",
                table: "State",
                newName: "initials");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "State",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "State_Id",
                table: "City",
                newName: "state_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "City",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "City",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_City_State_Id",
                table: "City",
                newName: "IX_City_state_id");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Address",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Complement",
                table: "Address",
                newName: "complement");

            migrationBuilder.RenameColumn(
                name: "City_Id",
                table: "Address",
                newName: "city_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Address_City_Id",
                table: "Address",
                newName: "IX_Address_city_id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "State",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "initials",
                table: "State",
                type: "varchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "City",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "street",
                table: "Address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "complement",
                table: "Address",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Address",
                type: "varchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_city_id",
                table: "Address",
                column: "city_id",
                principalTable: "City",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_state_id",
                table: "City",
                column: "state_id",
                principalTable: "State",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_City_city_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_City_State_state_id",
                table: "City");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "State",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "initials",
                table: "State",
                newName: "Initials");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "State",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "state_id",
                table: "City",
                newName: "State_Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "City",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "City",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_City_state_id",
                table: "City",
                newName: "IX_City_State_Id");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Address",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Address",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "complement",
                table: "Address",
                newName: "Complement");

            migrationBuilder.RenameColumn(
                name: "city_id",
                table: "Address",
                newName: "City_Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Address",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Address_city_id",
                table: "Address",
                newName: "IX_Address_City_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Initials",
                table: "State",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "City",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Complement",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(9)");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_City_City_Id",
                table: "Address",
                column: "City_Id",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_State_Id",
                table: "City",
                column: "State_Id",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
