using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP3.Migrations
{
    public partial class genreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 45,
                column: "GenreName",
                value: "GenreFromJsonFile2");

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 54,
                column: "GenreName",
                value: "GenreFromJsonFile1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 45,
                column: "GenreName",
                value: null);

            migrationBuilder.UpdateData(
                table: "genres",
                keyColumn: "Id",
                keyValue: 54,
                column: "GenreName",
                value: null);
        }
    }
}
