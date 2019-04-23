using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1PackagesSender.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainPackages",
                columns: table => new
                {
                    PK_MainPackages = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PACK_NameOfPackage = table.Column<string>(nullable: true),
                    PACK_DateOfMadeThePackage = table.Column<DateTime>(nullable: false),
                    PACK_IsPackageOpen = table.Column<bool>(nullable: false),
                    PACK_DateOfCloseThePackage = table.Column<DateTime>(nullable: true),
                    PACK_DestinationCityOfDelivery = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainPackages", x => x.PK_MainPackages);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    PK_Deliveries = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DEL_NameOfPackage = table.Column<string>(nullable: true),
                    DEL_AddressOfDestination = table.Column<string>(nullable: true),
                    DEL_DateOfMade = table.Column<DateTime>(nullable: false),
                    DEL_WeightOfDelivery = table.Column<double>(name: "DEL_WeightOfDelivery ", nullable: false),
                    FK_Deliveries_MainPackages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.PK_Deliveries);
                    table.ForeignKey(
                        name: "FK_Deliveries_MainPackages_FK_Deliveries_MainPackages",
                        column: x => x.FK_Deliveries_MainPackages,
                        principalTable: "MainPackages",
                        principalColumn: "PK_MainPackages",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_FK_Deliveries_MainPackages",
                table: "Deliveries",
                column: "FK_Deliveries_MainPackages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "MainPackages");
        }
    }
}
