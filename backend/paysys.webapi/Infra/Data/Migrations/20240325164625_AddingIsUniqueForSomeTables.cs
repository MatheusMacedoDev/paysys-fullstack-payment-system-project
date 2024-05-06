using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingIsUniqueForSomeTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_user_name",
                table: "users",
                column: "user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_types_user_type_name",
                table: "user_types",
                column: "user_type_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_shopkeepers_shopkeeper_cnpj",
                table: "shopkeepers",
                column: "shopkeeper_cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_common_users_common_user_cpf",
                table: "common_users",
                column: "common_user_cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_administrator_users_administrator_cpf",
                table: "administrator_users",
                column: "administrator_cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_users_email",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_user_name",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_user_types_user_type_name",
                table: "user_types");

            migrationBuilder.DropIndex(
                name: "IX_shopkeepers_shopkeeper_cnpj",
                table: "shopkeepers");

            migrationBuilder.DropIndex(
                name: "IX_common_users_common_user_cpf",
                table: "common_users");

            migrationBuilder.DropIndex(
                name: "IX_administrator_users_administrator_cpf",
                table: "administrator_users");
        }
    }
}
