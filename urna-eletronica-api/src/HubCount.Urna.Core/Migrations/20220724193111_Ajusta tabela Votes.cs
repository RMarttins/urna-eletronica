using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HubCount.Urna.Core.Migrations
{
    public partial class AjustatabelaVotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TYPE_VOTE",
                table: "TB_VOTE",
                type: "DECIMAL(1,0)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 1,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 2,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 3,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(48));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 4,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(50));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 5,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(53));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 6,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 24, 16, 31, 11, 12, DateTimeKind.Local).AddTicks(55));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TYPE_VOTE",
                table: "TB_VOTE");

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 1,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 2,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3180));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 3,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 4,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3186));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 5,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3188));

            migrationBuilder.UpdateData(
                table: "TB_CANDIDATE",
                keyColumn: "ID",
                keyValue: 6,
                column: "DT_CREATE",
                value: new DateTime(2022, 7, 23, 14, 13, 57, 441, DateTimeKind.Local).AddTicks(3190));
        }
    }
}
