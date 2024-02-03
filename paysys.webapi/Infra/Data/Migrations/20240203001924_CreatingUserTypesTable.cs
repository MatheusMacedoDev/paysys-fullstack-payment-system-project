using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingUserTypesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
