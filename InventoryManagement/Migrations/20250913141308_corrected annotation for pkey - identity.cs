using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class correctedannotationforpkeyidentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Id",
                schema: "shared",
                startValue: 100000L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100000,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 14, 13, 8, 532, DateTimeKind.Utc).AddTicks(1592));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100001,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 14, 13, 8, 532, DateTimeKind.Utc).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100002,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 3, 14, 13, 8, 532, DateTimeKind.Utc).AddTicks(1659));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100003,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 14, 13, 8, 532, DateTimeKind.Utc).AddTicks(1661));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RestartSequence(
                name: "Id",
                schema: "shared",
                startValue: 100004L);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100000,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 29, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1721));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100001,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 1, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100002,
                column: "CreatedAt",
                value: new DateTime(2025, 9, 3, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1730));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100003,
                column: "CreatedAt",
                value: new DateTime(2025, 8, 23, 14, 9, 47, 406, DateTimeKind.Utc).AddTicks(1732));
        }
    }
}
