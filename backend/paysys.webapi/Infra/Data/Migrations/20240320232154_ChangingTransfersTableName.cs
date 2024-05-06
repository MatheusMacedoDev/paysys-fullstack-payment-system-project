using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangingTransfersTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfer_transfer_categories_transfer_category_id",
                table: "transfer");

            migrationBuilder.DropForeignKey(
                name: "FK_transfer_transfer_status_transfer_status_id",
                table: "transfer");

            migrationBuilder.DropForeignKey(
                name: "FK_transfer_users_receiver_user_id",
                table: "transfer");

            migrationBuilder.DropForeignKey(
                name: "FK_transfer_users_sender_user_id",
                table: "transfer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transfer",
                table: "transfer");

            migrationBuilder.RenameTable(
                name: "transfer",
                newName: "transfers");

            migrationBuilder.RenameIndex(
                name: "IX_transfer_transfer_status_id",
                table: "transfers",
                newName: "IX_transfers_transfer_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfer_transfer_category_id",
                table: "transfers",
                newName: "IX_transfers_transfer_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfer_sender_user_id",
                table: "transfers",
                newName: "IX_transfers_sender_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfer_receiver_user_id",
                table: "transfers",
                newName: "IX_transfers_receiver_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transfers",
                table: "transfers",
                column: "tranfer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_transfer_categories_transfer_category_id",
                table: "transfers",
                column: "transfer_category_id",
                principalTable: "transfer_categories",
                principalColumn: "transfer_category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_transfer_status_transfer_status_id",
                table: "transfers",
                column: "transfer_status_id",
                principalTable: "transfer_status",
                principalColumn: "transfer_status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_users_receiver_user_id",
                table: "transfers",
                column: "receiver_user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfers_users_sender_user_id",
                table: "transfers",
                column: "sender_user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transfers_transfer_categories_transfer_category_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_transfer_status_transfer_status_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_users_receiver_user_id",
                table: "transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_transfers_users_sender_user_id",
                table: "transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_transfers",
                table: "transfers");

            migrationBuilder.RenameTable(
                name: "transfers",
                newName: "transfer");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_transfer_status_id",
                table: "transfer",
                newName: "IX_transfer_transfer_status_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_transfer_category_id",
                table: "transfer",
                newName: "IX_transfer_transfer_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_sender_user_id",
                table: "transfer",
                newName: "IX_transfer_sender_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_transfers_receiver_user_id",
                table: "transfer",
                newName: "IX_transfer_receiver_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_transfer",
                table: "transfer",
                column: "tranfer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_transfer_categories_transfer_category_id",
                table: "transfer",
                column: "transfer_category_id",
                principalTable: "transfer_categories",
                principalColumn: "transfer_category_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_transfer_status_transfer_status_id",
                table: "transfer",
                column: "transfer_status_id",
                principalTable: "transfer_status",
                principalColumn: "transfer_status_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_users_receiver_user_id",
                table: "transfer",
                column: "receiver_user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transfer_users_sender_user_id",
                table: "transfer",
                column: "sender_user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
