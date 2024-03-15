using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTransfersValueObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "transfer_category_name",
                table: "transfer");

            migrationBuilder.DropColumn(
                name: "transfer_status_name",
                table: "transfer");

            migrationBuilder.AddColumn<Guid>(
                name: "transfer_category_id",
                table: "transfer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "transfer_status_id",
                table: "transfer",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "transfer_category",
                columns: table => new
                {
                    transfer_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transfer_category_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_category", x => x.transfer_category_id);
                });

            migrationBuilder.CreateTable(
                name: "transfer_status",
                columns: table => new
                {
                    transfer_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transfer_status_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer_status", x => x.transfer_status_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transfer_category_id",
                table: "transfer",
                column: "transfer_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_transfer_status_id",
                table: "transfer",
                column: "transfer_status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_transfer_category_transfer_category_id",
                table: "transfer",
                column: "transfer_category_id",
                principalTable: "transfer_category",
                principalColumn: "transfer_category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_transfer_status_transfer_status_id",
                table: "transfer",
                column: "transfer_status_id",
                principalTable: "transfer_status",
                principalColumn: "transfer_status_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfer_transfer_category_transfer_category_id",
                table: "transfer");

            migrationBuilder.DropForeignKey(
                name: "FK_transfer_transfer_status_transfer_status_id",
                table: "transfer");

            migrationBuilder.DropTable(
                name: "transfer_category");

            migrationBuilder.DropTable(
                name: "transfer_status");

            migrationBuilder.DropIndex(
                name: "IX_transfer_transfer_category_id",
                table: "transfer");

            migrationBuilder.DropIndex(
                name: "IX_transfer_transfer_status_id",
                table: "transfer");

            migrationBuilder.DropColumn(
                name: "transfer_category_id",
                table: "transfer");

            migrationBuilder.DropColumn(
                name: "transfer_status_id",
                table: "transfer");

            migrationBuilder.AddColumn<string>(
                name: "transfer_category_name",
                table: "transfer",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "transfer_status_name",
                table: "transfer",
                type: "text",
                nullable: true);
        }
    }
}
