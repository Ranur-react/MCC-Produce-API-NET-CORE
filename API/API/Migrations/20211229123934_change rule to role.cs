using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class changeruletorole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_AccountRule");

            migrationBuilder.DropTable(
                name: "Tb_M_Rule");

            migrationBuilder.CreateTable(
                name: "Tb_M_Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_AccountRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Role = table.Column<int>(type: "int", nullable: false),
                    Id_Account = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Account_Id_Account",
                        column: x => x.Id_Account,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRole_Tb_M_Role_Id_Role",
                        column: x => x.Id_Role,
                        principalTable: "Tb_M_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRole_Id_Account",
                table: "Tb_M_AccountRole",
                column: "Id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRole_Id_Role",
                table: "Tb_M_AccountRole",
                column: "Id_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_M_AccountRole");

            migrationBuilder.DropTable(
                name: "Tb_M_Role");

            migrationBuilder.CreateTable(
                name: "Tb_M_Rule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_Rule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_M_AccountRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Account = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Id_Rule = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_M_AccountRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRule_Tb_M_Account_Id_Account",
                        column: x => x.Id_Account,
                        principalTable: "Tb_M_Account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_M_AccountRule_Tb_M_Rule_Id_Rule",
                        column: x => x.Id_Rule,
                        principalTable: "Tb_M_Rule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRule_Id_Account",
                table: "Tb_M_AccountRule",
                column: "Id_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_M_AccountRule_Id_Rule",
                table: "Tb_M_AccountRule",
                column: "Id_Rule");
        }
    }
}
