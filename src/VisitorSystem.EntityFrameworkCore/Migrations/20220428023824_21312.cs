using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorSystem.Migrations
{
    public partial class _21312 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SinevaUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Openid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SinevaUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Openid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorCarID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorToOpenid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorToName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorToPhoneNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CovidTestReport = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorRecords", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SinevaUsers");

            migrationBuilder.DropTable(
                name: "VisitorRecords");
        }
    }
}
