using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisitorSystem.Migrations
{
    public partial class InitialCreat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSendToStaff",
                table: "VisitorRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSendToUser",
                table: "VisitorRecords",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "VisitorTime",
                table: "VisitorRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSendToStaff",
                table: "VisitorRecords");

            migrationBuilder.DropColumn(
                name: "IsSendToUser",
                table: "VisitorRecords");

            migrationBuilder.DropColumn(
                name: "VisitorTime",
                table: "VisitorRecords");
        }
    }
}
