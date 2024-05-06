using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAllCommonUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommonUsers_Users_UserId",
                table: "CommonUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommonUsers",
                table: "CommonUsers");

            migrationBuilder.RenameTable(
                name: "CommonUsers",
                newName: "common_users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "common_users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CommonUserName",
                table: "common_users",
                newName: "common_user_name");

            migrationBuilder.RenameColumn(
                name: "CommonUserCPF",
                table: "common_users",
                newName: "common_user_cpf");

            migrationBuilder.RenameColumn(
                name: "CommonUserId",
                table: "common_users",
                newName: "common_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_CommonUsers_UserId",
                table: "common_users",
                newName: "IX_common_users_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_common_users",
                table: "common_users",
                column: "common_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_common_users_Users_user_id",
                table: "common_users",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_common_users_Users_user_id",
                table: "common_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_common_users",
                table: "common_users");

            migrationBuilder.RenameTable(
                name: "common_users",
                newName: "CommonUsers");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CommonUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "common_user_name",
                table: "CommonUsers",
                newName: "CommonUserName");

            migrationBuilder.RenameColumn(
                name: "common_user_cpf",
                table: "CommonUsers",
                newName: "CommonUserCPF");

            migrationBuilder.RenameColumn(
                name: "common_user_id",
                table: "CommonUsers",
                newName: "CommonUserId");

            migrationBuilder.RenameIndex(
                name: "IX_common_users_user_id",
                table: "CommonUsers",
                newName: "IX_CommonUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommonUsers",
                table: "CommonUsers",
                column: "CommonUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommonUsers_Users_UserId",
                table: "CommonUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
