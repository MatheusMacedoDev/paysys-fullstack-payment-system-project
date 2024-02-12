using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingCommonUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonUsers",
                columns: table => new
                {
                    CommonUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommonUserName = table.Column<string>(type: "text", nullable: false),
                    CommonUserCPF = table.Column<string>(type: "CHAR(11)", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonUsers", x => x.CommonUserId);
                    table.ForeignKey(
                        name: "FK_CommonUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommonUsers_UserId",
                table: "CommonUsers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonUsers");
        }
    }
}
