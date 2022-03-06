using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Migrations
{
    public partial class KlassEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Klasser_Lärare_KlassföreståndareID",
                table: "Klasser");

            migrationBuilder.DropIndex(
                name: "IX_Klasser_KlassföreståndareID",
                table: "Klasser");

            migrationBuilder.DropColumn(
                name: "KlassföreståndareID",
                table: "Klasser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KlassföreståndareID",
                table: "Klasser",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Klasser_KlassföreståndareID",
                table: "Klasser",
                column: "KlassföreståndareID");

            migrationBuilder.AddForeignKey(
                name: "FK_Klasser_Lärare_KlassföreståndareID",
                table: "Klasser",
                column: "KlassföreståndareID",
                principalTable: "Lärare",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
