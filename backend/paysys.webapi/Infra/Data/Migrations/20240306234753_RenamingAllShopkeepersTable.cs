using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamingAllShopkeepersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shopkeepers_Users_UserId",
                table: "Shopkeepers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shopkeepers",
                table: "Shopkeepers");

            migrationBuilder.RenameTable(
                name: "Shopkeepers",
                newName: "shopkeeper");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "shopkeeper",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "shopkeeper",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ShopkeeperCNJP",
                table: "shopkeeper",
                newName: "shopkeeper_cnpj");

            migrationBuilder.RenameColumn(
                name: "FancyName",
                table: "shopkeeper",
                newName: "fancy_name");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "shopkeeper",
                newName: "company_name");

            migrationBuilder.RenameColumn(
                name: "ShopkeeperId",
                table: "shopkeeper",
                newName: "shopkeeper_id");

            migrationBuilder.RenameIndex(
                name: "IX_Shopkeepers_UserId",
                table: "shopkeeper",
                newName: "IX_shopkeeper_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_shopkeeper",
                table: "shopkeeper",
                column: "shopkeeper_id");

            migrationBuilder.AddForeignKey(
                name: "FK_shopkeeper_Users_user_id",
                table: "shopkeeper",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopkeeper_Users_user_id",
                table: "shopkeeper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_shopkeeper",
                table: "shopkeeper");

            migrationBuilder.RenameTable(
                name: "shopkeeper",
                newName: "Shopkeepers");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Shopkeepers",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Shopkeepers",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "shopkeeper_cnpj",
                table: "Shopkeepers",
                newName: "ShopkeeperCNJP");

            migrationBuilder.RenameColumn(
                name: "fancy_name",
                table: "Shopkeepers",
                newName: "FancyName");

            migrationBuilder.RenameColumn(
                name: "company_name",
                table: "Shopkeepers",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "shopkeeper_id",
                table: "Shopkeepers",
                newName: "ShopkeeperId");

            migrationBuilder.RenameIndex(
                name: "IX_shopkeeper_user_id",
                table: "Shopkeepers",
                newName: "IX_Shopkeepers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shopkeepers",
                table: "Shopkeepers",
                column: "ShopkeeperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shopkeepers_Users_UserId",
                table: "Shopkeepers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
