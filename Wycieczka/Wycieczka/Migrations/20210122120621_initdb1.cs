using Microsoft.EntityFrameworkCore.Migrations;

namespace Wycieczka.Migrations
{
    public partial class initdb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WycieczkaInfos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miejsce_Start = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miejsce_Docelowe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ilosc_Km = table.Column<double>(type: "float", nullable: false),
                    Liczba_Dni = table.Column<int>(type: "int", nullable: false),
                    Url_Zdj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url_Filmu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WycieczkaInfos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zdjecias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url_zdj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WycieczkaInfoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zdjecias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zdjecias_WycieczkaInfos_WycieczkaInfoID",
                        column: x => x.WycieczkaInfoID,
                        principalTable: "WycieczkaInfos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Zdjecias_WycieczkaInfoID",
                table: "Zdjecias",
                column: "WycieczkaInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Zdjecias");

            migrationBuilder.DropTable(
                name: "WycieczkaInfos");
        }
    }
}
