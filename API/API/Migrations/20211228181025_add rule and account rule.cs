using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class addruleandaccountrule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_M_Rule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Rule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_AccountRule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_rule = table.Column<int>(type: "int", nullable: false),
                    id_Account = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRule", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRule_Tb_M_Account_id_Account",
                        column: x => x.id_Account,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRule_Tb_M_Rule_id_rule",
                        column: x => x.id_rule,
                        principalTable: "Tb_M_Rule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRule_id_Account",
                table: "Tb_M_AccountRule",
                column: "id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRule_id_rule",
                table: "Tb_M_AccountRule",
                column: "id_rule");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_AccountRule");

            migrationBuilder.DropTable(
                name: "Tb_M_Rule");
        }
    }
}
