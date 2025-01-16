using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForTransfer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "transfers",
                columns: new[] { "transfer_id", "receiver_user_id", "sender_user_id", "transfer_amount", "transfer_category_id", "transfer_datetime", "transfer_status_id", "transfer_description" },
                values: new object[] { new Guid("216a0718-b9bf-4ad2-84ad-7e125ead9e10"), new Guid("46121131-1507-4470-83ea-dd0439c51b4c"), new Guid("8499d00f-fac1-4296-9b2c-d2143cbf1563"), 2469.93m, new Guid("bc7e2062-9aad-4e59-afdb-52733ac514e4"), new DateTime(2025, 1, 16, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4845), new Guid("5e55e212-6419-4c21-b9b6-6fa65e636978"), "Notebook ASUS VivoBook Go 15, AMD RYZEN 5 7520U, 8GB, 256GB SSD, KeepOS, Tela 15,6 pol FHD, Mixed Black - E1504FA-NJ731" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transfers",
                keyColumn: "transfer_id",
                keyValue: new Guid("216a0718-b9bf-4ad2-84ad-7e125ead9e10"));
        }
    }
}
