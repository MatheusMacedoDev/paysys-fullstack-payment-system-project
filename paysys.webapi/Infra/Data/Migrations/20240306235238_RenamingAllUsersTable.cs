using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAllUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_administrator_users_Users_user_id",
                table: "administrator_users");

            migrationBuilder.DropForeignKey(
                name: "FK_common_users_Users_user_id",
                table: "common_users");

            migrationBuilder.DropForeignKey(
                name: "FK_shopkeeper_Users_user_id",
                table: "shopkeeper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "Salt",
                table: "users",
                newName: "salt");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "users",
                newName: "hash");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "users",
                newName: "user_type_id");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "users",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "users",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedOn",
                table: "users",
                newName: "last_updated_on");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "users",
                newName: "created_on");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "users",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "users",
                newName: "IX_users_user_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_administrator_users_users_user_id",
                table: "administrator_users",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_common_users_users_user_id",
                table: "common_users",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopkeeper_users_user_id",
                table: "shopkeeper",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_users_UserTypes_user_type_id",
                table: "users",
                column: "user_type_id",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_administrator_users_users_user_id",
                table: "administrator_users");

            migrationBuilder.DropForeignKey(
                name: "FK_common_users_users_user_id",
                table: "common_users");

            migrationBuilder.DropForeignKey(
                name: "FK_shopkeeper_users_user_id",
                table: "shopkeeper");

            migrationBuilder.DropForeignKey(
                name: "FK_users_UserTypes_user_type_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "salt",
                table: "Users",
                newName: "Salt");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "Users",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "user_type_id",
                table: "Users",
                newName: "UserTypeId");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "Users",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "last_updated_on",
                table: "Users",
                newName: "LastUpdatedOn");

            migrationBuilder.RenameColumn(
                name: "created_on",
                table: "Users",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_users_user_type_id",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_administrator_users_Users_user_id",
                table: "administrator_users",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_common_users_Users_user_id",
                table: "common_users",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_shopkeeper_Users_user_id",
                table: "shopkeeper",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
