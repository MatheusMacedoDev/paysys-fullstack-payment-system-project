using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAllAdministratorUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdministratorUsers_Users_UserId",
                table: "AdministratorUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdministratorUsers",
                table: "AdministratorUsers");

            migrationBuilder.RenameTable(
                name: "AdministratorUsers",
                newName: "administrator_users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "administrator_users",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "AdministratorName",
                table: "administrator_users",
                newName: "administrator_name");

            migrationBuilder.RenameColumn(
                name: "AdministratorCPF",
                table: "administrator_users",
                newName: "administrator_cpf");

            migrationBuilder.RenameColumn(
                name: "AdministratorId",
                table: "administrator_users",
                newName: "administrator_id");

            migrationBuilder.RenameIndex(
                name: "IX_AdministratorUsers_UserId",
                table: "administrator_users",
                newName: "IX_administrator_users_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_administrator_users",
                table: "administrator_users",
                column: "administrator_id");

            migrationBuilder.AddForeignKey(
                name: "FK_administrator_users_Users_user_id",
                table: "administrator_users",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_administrator_users_Users_user_id",
                table: "administrator_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_administrator_users",
                table: "administrator_users");

            migrationBuilder.RenameTable(
                name: "administrator_users",
                newName: "AdministratorUsers");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AdministratorUsers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "administrator_name",
                table: "AdministratorUsers",
                newName: "AdministratorName");

            migrationBuilder.RenameColumn(
                name: "administrator_cpf",
                table: "AdministratorUsers",
                newName: "AdministratorCPF");

            migrationBuilder.RenameColumn(
                name: "administrator_id",
                table: "AdministratorUsers",
                newName: "AdministratorId");

            migrationBuilder.RenameIndex(
                name: "IX_administrator_users_user_id",
                table: "AdministratorUsers",
                newName: "IX_AdministratorUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdministratorUsers",
                table: "AdministratorUsers",
                column: "AdministratorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdministratorUsers_Users_UserId",
                table: "AdministratorUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
