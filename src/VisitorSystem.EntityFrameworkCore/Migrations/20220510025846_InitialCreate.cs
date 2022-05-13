using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitorToPhoneNum",
                table: "VisitorRecords",
                newName: "VisitToPhoneNum");

            migrationBuilder.RenameColumn(
                name: "VisitorToOpenid",
                table: "VisitorRecords",
                newName: "VisitToOpenid");

            migrationBuilder.RenameColumn(
                name: "VisitorToName",
                table: "VisitorRecords",
                newName: "VisitToName");

            migrationBuilder.RenameColumn(
                name: "VisitorTime",
                table: "VisitorRecords",
                newName: "VisitTime");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "SinevaUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VisitToPhoneNum",
                table: "VisitorRecords",
                newName: "VisitorToPhoneNum");

            migrationBuilder.RenameColumn(
                name: "VisitToOpenid",
                table: "VisitorRecords",
                newName: "VisitorToOpenid");

            migrationBuilder.RenameColumn(
                name: "VisitToName",
                table: "VisitorRecords",
                newName: "VisitorToName");

            migrationBuilder.RenameColumn(
                name: "VisitTime",
                table: "VisitorRecords",
                newName: "VisitorTime");

            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "SinevaUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
