using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForUserTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_types",
                columns: new[] { "user_type_id", "user_type_name" },
                values: new object[,]
                {
                    { new Guid("0eb973a0-8788-44ca-816b-2ed7dd2ea7e4"), "Administrador" },
                    { new Guid("349293cd-cbf6-45ce-a8a5-593a32519d46"), "Comum" },
                    { new Guid("b3a1ff2a-a9e4-4024-8ef7-410da9ea8433"), "Lojista" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "user_type_id",
                keyValue: new Guid("0eb973a0-8788-44ca-816b-2ed7dd2ea7e4"));

            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "user_type_id",
                keyValue: new Guid("349293cd-cbf6-45ce-a8a5-593a32519d46"));

            migrationBuilder.DeleteData(
                table: "user_types",
                keyColumn: "user_type_id",
                keyValue: new Guid("b3a1ff2a-a9e4-4024-8ef7-410da9ea8433"));
        }
    }
}
