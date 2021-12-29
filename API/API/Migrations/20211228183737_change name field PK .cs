using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changenamefieldPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Account_id_Account",
                table: "Tb_M_AccountRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Rule_id_rule",
                table: "Tb_M_AccountRule");

            migrationBuilder.RenameColumn(
                name: "id_rule",
                table: "Tb_M_AccountRule",
                newName: "Id_Rule");

            migrationBuilder.RenameColumn(
                name: "id_Account",
                table: "Tb_M_AccountRule",
                newName: "Id_Account");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_AccountRule_id_rule",
                table: "Tb_M_AccountRule",
                newName: "IX_Tb_M_AccountRule_Id_Rule");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_AccountRule_id_Account",
                table: "Tb_M_AccountRule",
                newName: "IX_Tb_M_AccountRule_Id_Account");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Account_Id_Account",
                table: "Tb_M_AccountRule",
                column: "Id_Account",
                principalTable: "Tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Rule_Id_Rule",
                table: "Tb_M_AccountRule",
                column: "Id_Rule",
                principalTable: "Tb_M_Rule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Account_Id_Account",
                table: "Tb_M_AccountRule");

            migrationBuilder.DropForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Rule_Id_Rule",
                table: "Tb_M_AccountRule");

            migrationBuilder.RenameColumn(
                name: "Id_Rule",
                table: "Tb_M_AccountRule",
                newName: "id_rule");

            migrationBuilder.RenameColumn(
                name: "Id_Account",
                table: "Tb_M_AccountRule",
                newName: "id_Account");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_AccountRule_Id_Rule",
                table: "Tb_M_AccountRule",
                newName: "IX_Tb_M_AccountRule_id_rule");

            migrationBuilder.RenameIndex(
                name: "IX_Tb_M_AccountRule_Id_Account",
                table: "Tb_M_AccountRule",
                newName: "IX_Tb_M_AccountRule_id_Account");

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Account_id_Account",
                table: "Tb_M_AccountRule",
                column: "id_Account",
                principalTable: "Tb_M_Account",
                principalColumn: "NIK",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tb_M_AccountRule_Tb_M_Rule_id_rule",
                table: "Tb_M_AccountRule",
                column: "id_rule",
                principalTable: "Tb_M_Rule",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
