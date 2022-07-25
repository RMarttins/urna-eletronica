using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubCount.Urna.Core.Migrations
{
    public partial class AjustatabelaCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PARTIDO",
                table: "TB_CANDIDATE",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3156), "SOLID" });

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3180), "CQRS" });

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3183), "DDD" });

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3186), "TDD" });

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3188), "BDD" });

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 6,
                columns: new[] { "DT_CREATE", "PARTIDO" },
                values: new object[] { new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3190), "GIT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PARTIDO",
                table: "TB_CANDIDATE");

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 1,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(4994));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 2,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5010));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 3,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5012));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 4,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5014));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 5,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5019));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 6,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 18, 18, 49, 59, 897, DateTimeKind.Local).AddTicks(5020));
        }
    }
}
