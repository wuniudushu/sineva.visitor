using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorSystem.Migrations
{
    public partial class Add_CardID2222 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "SinevaUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Company",
                table: "SinevaUsers");
        }
    }
}
