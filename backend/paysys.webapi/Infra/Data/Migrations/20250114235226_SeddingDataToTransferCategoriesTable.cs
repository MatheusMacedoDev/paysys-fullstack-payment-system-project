using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeddingDataToTransferCategoriesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "transfer_categories",
                columns: new[] { "transfer_category_id", "transfer_category_name" },
                values: new object[,]
                {
                    { new Guid("2e6c6eaf-5d25-4241-b1b0-7d3433824861"), "Transporte" },
                    { new Guid("384b4ec9-f5ac-406e-b2a2-52733dcc73de"), "Hotelaria" },
                    { new Guid("9bba9f3e-234f-4ec5-aac3-d2e99f46a59a"), "Alimentação" },
                    { new Guid("bc7e2062-9aad-4e59-afdb-52733ac514e4"), "Tecnologia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transfer_categories",
                keyColumn: "transfer_category_id",
                keyValue: new Guid("2e6c6eaf-5d25-4241-b1b0-7d3433824861"));

            migrationBuilder.DeleteData(
                table: "transfer_categories",
                keyColumn: "transfer_category_id",
                keyValue: new Guid("384b4ec9-f5ac-406e-b2a2-52733dcc73de"));

            migrationBuilder.DeleteData(
                table: "transfer_categories",
                keyColumn: "transfer_category_id",
                keyValue: new Guid("9bba9f3e-234f-4ec5-aac3-d2e99f46a59a"));

            migrationBuilder.DeleteData(
                table: "transfer_categories",
                keyColumn: "transfer_category_id",
                keyValue: new Guid("bc7e2062-9aad-4e59-afdb-52733ac514e4"));
        }
    }
}
