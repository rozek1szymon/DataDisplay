using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1PackagesSender.Migrations
{
    public partial class InitialABC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptingPeople",
                columns: table => new
                {
                    ACP_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ACP_Category = table.Column<string>(nullable: false),
                    ACP_Login = table.Column<string>(nullable: false),
                    ACP_Limit = table.Column<decimal>(nullable: false),
                    ACP_SubstituteLogin = table.Column<string>(nullable: true),
                    ACP_SubstituteLimit = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptingPeople", x => x.ACP_ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ORG_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ORG_Name = table.Column<string>(nullable: false),
                    ORG_Login = table.Column<string>(nullable: false),
                    ORG_ManagerID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ORG_ID);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ORG_ManagerID",
                        column: x => x.ORG_ManagerID,
                        principalTable: "Employees",
                        principalColumn: "ORG_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ORG_ManagerID",
                table: "Employees",
                column: "ORG_ManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptingPeople");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
