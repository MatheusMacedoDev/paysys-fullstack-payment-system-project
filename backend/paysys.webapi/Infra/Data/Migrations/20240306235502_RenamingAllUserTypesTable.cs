using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAllUserTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_UserTypes_user_type_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.RenameTable(
                name: "UserTypes",
                newName: "user_types");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "user_types",
                newName: "user_type_name");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "user_types",
                newName: "user_type_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_types",
                table: "user_types",
                column: "user_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_types_user_type_id",
                table: "users",
                column: "user_type_id",
                principalTable: "user_types",
                principalColumn: "user_type_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_user_types_user_type_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_types",
                table: "user_types");

            migrationBuilder.RenameTable(
                name: "user_types",
                newName: "UserTypes");

            migrationBuilder.RenameColumn(
                name: "user_type_name",
                table: "UserTypes",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "user_type_id",
                table: "UserTypes",
                newName: "UserTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_users_UserTypes_user_type_id",
                table: "users",
                column: "user_type_id",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
