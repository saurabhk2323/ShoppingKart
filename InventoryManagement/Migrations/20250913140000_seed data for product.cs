using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InventoryManagement.Migrations
{
    /// <inheritdoc />
    public partial class seeddataforproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "StockAvailable", "UpdatedAt" },
                values: new object[,]
                {
                    { 100000, "Electronics", new DateTime(2025, 8, 29, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3919), "16GB RAM, 512GB SSD", "Laptop", 89999.99m, 10, null },
                    { 100001, "Electronics", new DateTime(2025, 9, 1, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3927), "5G-enabled device", "Smartphone", 49999.50m, 25, null },
                    { 100002, "Stationery", new DateTime(2025, 9, 3, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3928), "200 pages, ruled", "Notebook", 59.99m, 500, null },
                    { 100003, "Appliances", new DateTime(2025, 8, 23, 14, 0, 0, 237, DateTimeKind.Utc).AddTicks(3930), "3-speed oscillation", "Table Fan", 1299.99m, 100, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100000);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100001);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100002);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100003);
        }
    }
}
