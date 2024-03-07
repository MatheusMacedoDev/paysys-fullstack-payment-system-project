using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixingShopkeepersTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopkeeper_users_user_id",
                table: "shopkeeper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopkeeper",
                table: "shopkeeper");

            migrationBuilder.RenameTable(
                name: "shopkeeper",
                newName: "shopkeepers");

            migrationBuilder.RenameIndex(
                name: "IX_shopkeeper_user_id",
                table: "shopkeepers",
                newName: "IX_shopkeepers_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopkeepers",
                table: "shopkeepers",
                column: "shopkeeper_id");

            migrationBuilder.AddForeignKey(
                name: "FK_shopkeepers_users_user_id",
                table: "shopkeepers",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopkeepers_users_user_id",
                table: "shopkeepers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopkeepers",
                table: "shopkeepers");

            migrationBuilder.RenameTable(
                name: "shopkeepers",
                newName: "shopkeeper");

            migrationBuilder.RenameIndex(
                name: "IX_shopkeepers_user_id",
                table: "shopkeeper",
                newName: "IX_shopkeeper_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopkeeper",
                table: "shopkeeper",
                column: "shopkeeper_id");

            migrationBuilder.AddForeignKey(
                name: "FK_shopkeeper_users_user_id",
                table: "shopkeeper",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
