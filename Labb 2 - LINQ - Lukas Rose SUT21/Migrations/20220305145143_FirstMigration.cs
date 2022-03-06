using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb_2___LINQ___Lukas_Rose_SUT21.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lärare",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FNamn = table.Column<string>(nullable: false),
                    LNamn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lärare", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klasser",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KlassNamn = table.Column<string>(nullable: true),
                    KlassföreståndareID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klasser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Klasser_Lärare_KlassföreståndareID",
                        column: x => x.KlassföreståndareID,
                        principalTable: "Lärare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ämnen",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ÄmnesNamn = table.Column<string>(nullable: true),
                    StartDatum = table.Column<DateTime>(nullable: false),
                    SlutDatum = table.Column<DateTime>(nullable: false),
                    LärareID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ämnen", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ämnen_Lärare_LärareID",
                        column: x => x.LärareID,
                        principalTable: "Lärare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Studenter",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalNum = table.Column<string>(nullable: false),
                    FName = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    KlassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenter", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Studenter_Klasser_KlassID",
                        column: x => x.KlassID,
                        principalTable: "Klasser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klasser_KlassföreståndareID",
                table: "Klasser",
                column: "KlassföreståndareID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenter_KlassID",
                table: "Studenter",
                column: "KlassID");

            migrationBuilder.CreateIndex(
                name: "IX_Ämnen_LärareID",
                table: "Ämnen",
                column: "LärareID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Studenter");

            migrationBuilder.DropTable(
                name: "Ämnen");

            migrationBuilder.DropTable(
                name: "Klasser");

            migrationBuilder.DropTable(
                name: "Lärare");
        }
    }
}
