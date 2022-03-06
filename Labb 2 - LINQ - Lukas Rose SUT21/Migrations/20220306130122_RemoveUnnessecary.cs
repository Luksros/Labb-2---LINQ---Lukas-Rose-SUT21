using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Migrations
{
    public partial class RemoveUnnessecary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlutDatum",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "StartDatum",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "PersonalNum",
                table: "Studenter");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SlutDatum",
                table: "Ämnen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDatum",
                table: "Ämnen",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PersonalNum",
                table: "Studenter",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
