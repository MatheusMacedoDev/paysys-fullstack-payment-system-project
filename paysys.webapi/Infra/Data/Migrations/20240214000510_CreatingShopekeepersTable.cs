using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingShopekeepersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shopkeepers",
                columns: table => new
                {
                    ShopkeeperId = table.Column<Guid>(type: "uuid", nullable: false),
                    FancyName = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    ShopkeeperCNJP = table.Column<string>(type: "CHAR(14)", nullable: false),
                    Balance = table.Column<decimal>(type: "MONEY", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shopkeepers", x => x.ShopkeeperId);
                    table.ForeignKey(
                        name: "FK_Shopkeepers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shopkeepers_UserId",
                table: "Shopkeepers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shopkeepers");
        }
    }
}
