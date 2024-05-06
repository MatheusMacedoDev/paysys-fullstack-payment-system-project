using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class MappingPasswordValueObjectIntoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "salt",
                table: "users",
                newName: "password_salt");

            migrationBuilder.RenameColumn(
                name: "hash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_salt",
                table: "users",
                type: "BYTEA",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BYTEA");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_hash",
                table: "users",
                type: "BYTEA",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "BYTEA");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password_salt",
                table: "users",
                newName: "salt");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "users",
                newName: "hash");

            migrationBuilder.AlterColumn<byte[]>(
                name: "salt",
                table: "users",
                type: "BYTEA",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "BYTEA",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "hash",
                table: "users",
                type: "BYTEA",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "BYTEA",
                oldNullable: true);
        }
    }
}
