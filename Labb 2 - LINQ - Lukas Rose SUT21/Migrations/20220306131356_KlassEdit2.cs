using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Migrations
{
    public partial class KlassEdit2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ÄmnesNamn",
                table: "Ämnen",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KlassID",
                table: "Ämnen",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KlassNamn",
                table: "Klasser",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_KlassID",
                table: "Ämnen",
                column: "KlassID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ämnen_Klasser_KlassID",
                table: "Ämnen",
                column: "KlassID",
                principalTable: "Klasser",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ämnen_Klasser_KlassID",
                table: "Ämnen");

            migrationBuilder.DropIndex(
                name: "IX_Ämnen_KlassID",
                table: "Ämnen");

            migrationBuilder.DropColumn(
                name: "KlassID",
                table: "Ämnen");

            migrationBuilder.AlterColumn<string>(
                name: "ÄmnesNamn",
                table: "Ämnen",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "KlassNamn",
                table: "Klasser",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
