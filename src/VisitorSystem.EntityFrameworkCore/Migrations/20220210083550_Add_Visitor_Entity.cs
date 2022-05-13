using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorSystem.Migrations
{
    public partial class Add_Visitor_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisitorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisitorPhoneNum = table.Column<int>(type: "int", nullable: false),
                    VisitorIDCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorCompany = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitors");
        }
    }
}
