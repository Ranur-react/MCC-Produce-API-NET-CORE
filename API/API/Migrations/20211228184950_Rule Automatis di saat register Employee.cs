using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RuleAutomatisdisaatregisterEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tb_M_Rule",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tb_M_Rule",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tb_M_AccountRule",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tb_M_Rule",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tb_M_Rule",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tb_M_AccountRule",
                newName: "id");
        }
    }
}
