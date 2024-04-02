using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingCPFValueObjectIntoCommonAndAdministratorUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "common_user_cpf",
                table: "common_users",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");

            migrationBuilder.AlterColumn<string>(
                name: "administrator_cpf",
                table: "administrator_users",
                type: "CHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(11)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "common_user_cpf",
                table: "common_users",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "administrator_cpf",
                table: "administrator_users",
                type: "CHAR(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(11)",
                oldNullable: true);
        }
    }
}
