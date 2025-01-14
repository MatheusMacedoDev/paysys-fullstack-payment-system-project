using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "created_on", "last_updated_on", "user_type_id", "email", "password_hash", "password_salt", "phone_number", "user_name" },
                values: new object[,]
                {
                    { new Guid("3c56843f-fd7a-41bd-8e14-a6b4832fa6fb"), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4826), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4826), new Guid("0eb973a0-8788-44ca-816b-2ed7dd2ea7e4"), "augusto.diego@paysys.com", new byte[] { 170, 88, 154, 122, 54, 152, 158, 118, 158, 154, 197, 61, 246, 108, 72, 60, 147, 232, 130, 253, 231, 194, 27, 66, 162, 185, 117, 175, 80, 1, 127, 174 }, new byte[] { 220, 94, 212, 255, 55, 103, 101, 178, 34, 111, 184, 195, 232, 110, 5, 22 }, "65996283505", "AugustoDiegoElias" },
                    { new Guid("46121131-1507-4470-83ea-dd0439c51b4c"), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4837), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4837), new Guid("b3a1ff2a-a9e4-4024-8ef7-410da9ea8433"), "ian.elias@novonegocio.com", new byte[] { 170, 88, 154, 122, 54, 152, 158, 118, 158, 154, 197, 61, 246, 108, 72, 60, 147, 232, 130, 253, 231, 194, 27, 66, 162, 185, 117, 175, 80, 1, 127, 174 }, new byte[] { 220, 94, 212, 255, 55, 103, 101, 178, 34, 111, 184, 195, 232, 110, 5, 22 }, "65996283506", "IanEliasMuriloOliveira" },
                    { new Guid("8499d00f-fac1-4296-9b2c-d2143cbf1563"), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4845), new DateTime(2025, 1, 14, 16, 56, 38, 553, DateTimeKind.Utc).AddTicks(4845), new Guid("349293cd-cbf6-45ce-a8a5-593a32519d46"), "gabriela.amanda@gmail.com", new byte[] { 170, 88, 154, 122, 54, 152, 158, 118, 158, 154, 197, 61, 246, 108, 72, 60, 147, 232, 130, 253, 231, 194, 27, 66, 162, 185, 117, 175, 80, 1, 127, 174 }, new byte[] { 220, 94, 212, 255, 55, 103, 101, 178, 34, 111, 184, 195, 232, 110, 5, 22 }, "65996283507", "GabrielaAmandaMelo" }
                });

            migrationBuilder.InsertData(
                table: "administrator_users",
                columns: new[] { "administrator_id", "administrator_name", "administrator_cpf", "user_id" },
                values: new object[,] {
                    { new Guid("83b4b309-d893-4620-bc19-3988d7ec36c3"), "Augusto Diego Elias", "30860307719", "3c56843f-fd7a-41bd-8e14-a6b4832fa6fb" }
                }
            );


            migrationBuilder.InsertData(
                table: "shopkeepers",
                columns: new[] { "shopkeeper_id", "fancy_name", "company_name", "shopkeeper_cnpj", "balance", "user_id" },
                values: new object[,] {
                    { new Guid("d8dde04c-bc75-4528-a4c5-743f36b41fb2"), "Novo Negócio", "Novo Negócio LTDA", "09523885000188", 0, "46121131-1507-4470-83ea-dd0439c51b4c" }
                }
            );

            migrationBuilder.InsertData(
                table: "common_users",
                columns: new[] { "common_user_id", "common_user_name", "common_user_cpf", "user_id" },
                values: new object[,] {
                    { new Guid("e7ad1fb8-a538-4188-8b18-abcde5486368"), "Gabriela Amanda Melo", "19959059251", "8499d00f-fac1-4296-9b2c-d2143cbf1563" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("3c56843f-fd7a-41bd-8e14-a6b4832fa6fb"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("46121131-1507-4470-83ea-dd0439c51b4c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: new Guid("8499d00f-fac1-4296-9b2c-d2143cbf1563"));

            migrationBuilder.DeleteData(
                table: "administrator_users",
                keyColumn: "administrator_id",
                keyValue: new Guid("83b4b309-d893-4620-bc19-3988d7ec36c3"));

            migrationBuilder.DeleteData(
                table: "shopkeepers",
                keyColumn: "shopkeeper_id",
                keyValue: new Guid("d8dde04c-bc75-4528-a4c5-743f36b41fb2"));

            migrationBuilder.DeleteData(
                table: "common_users",
                keyColumn: "common_user_id",
                keyValue: new Guid("e7ad1fb8-a538-4188-8b18-abcde5486368"));
        }
    }
}
