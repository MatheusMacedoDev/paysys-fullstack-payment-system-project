using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingAdministratorUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdministratorUsers",
                columns: table => new
                {
                    AdministratorId = table.Column<Guid>(type: "uuid", nullable: false),
                    AdministratorName = table.Column<string>(type: "text", nullable: false),
                    AdministratorCPF = table.Column<string>(type: "CHAR(11)", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministratorUsers", x => x.AdministratorId);
                    table.ForeignKey(
                        name: "FK_AdministratorUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministratorUsers_UserId",
                table: "AdministratorUsers",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdministratorUsers");
        }
    }
}
