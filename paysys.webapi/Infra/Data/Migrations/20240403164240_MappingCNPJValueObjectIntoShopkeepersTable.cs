using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingCNPJValueObjectIntoShopkeepersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shopkeeper_cnpj",
                table: "shopkeepers",
                type: "CHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(14)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "shopkeeper_cnpj",
                table: "shopkeepers",
                type: "CHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(14)",
                oldNullable: true);
        }
    }
}
