using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForTransferStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "transfer_status",
                columns: new[] { "transfer_status_id", "transfer_status_name" },
                values: new object[] { new Guid("5e55e212-6419-4c21-b9b6-6fa65e636978"), "Concluída" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "transfer_status",
                keyColumn: "transfer_status_id",
                keyValue: new Guid("5e55e212-6419-4c21-b9b6-6fa65e636978"));
        }
    }
}
