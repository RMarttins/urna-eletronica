using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubCount.Urna.Core.Migrations
{
    public partial class Adicionacandidatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lEGENDA",
                table: "TB_CANDIDATE",
                newName: "LEGENDA");

            migrationBuilder.InsertData(
                table: "TB_CANDIDATE",
                columns: new[] { "ID", "CANDIDATE_NAME", "DT_CREATE", "LEGENDA", "VICE_NAME" },
                values: new object[,]
                {
                    { 1, "Canditato Teste 001", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(4994), 10m, "Vice Canditato Teste 001" },
                    { 2, "Canditato Teste 002", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5010), 20m, "Vice Canditato Teste 002" },
                    { 3, "Canditato Teste 003", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5012), 30m, "Vice Canditato Teste 003" },
                    { 4, "Canditato Teste 004", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5014), 40m, "Vice Canditato Teste 004" },
                    { 5, "Canditato Teste 005", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5019), 50m, "Vice Canditato Teste 005" },
                    { 6, "Canditato Teste 006", new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5020), 60m, "Vice Canditato Teste 006" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.RenameColumn(
                name: "LEGENDA",
                table: "TB_CANDIDATE",
                newName: "lEGENDA");
        }
    }
}
