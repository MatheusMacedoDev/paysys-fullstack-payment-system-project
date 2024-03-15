using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TurningTransferStatusNameAndTransferCategoryNameUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "transfer_status_name",
                table: "transfer_status",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "transfer_category_name",
                table: "transfer_categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transfer_status_transfer_status_name",
                table: "transfer_status",
                column: "transfer_status_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_transfer_categories_transfer_category_name",
                table: "transfer_categories",
                column: "transfer_category_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_transfer_status_transfer_status_name",
                table: "transfer_status");

            migrationBuilder.DropIndex(
                name: "IX_transfer_categories_transfer_category_name",
                table: "transfer_categories");

            migrationBuilder.AlterColumn<string>(
                name: "transfer_status_name",
                table: "transfer_status",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "transfer_category_name",
                table: "transfer_categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
