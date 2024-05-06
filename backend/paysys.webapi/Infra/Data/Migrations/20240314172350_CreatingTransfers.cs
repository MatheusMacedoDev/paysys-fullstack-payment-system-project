using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace paysys.webapi.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTransfers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transfer",
                columns: table => new
                {
                    tranfer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    transfer_description = table.Column<string>(type: "text", nullable: false),
                    transfer_amount = table.Column<decimal>(type: "MONEY", nullable: false),
                    transfer_datetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    transfer_status_name = table.Column<string>(type: "text", nullable: true),
                    transfer_category_name = table.Column<string>(type: "text", nullable: true),
                    sender_user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    receiver_user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transfer", x => x.tranfer_id);
                    table.ForeignKey(
                        name: "FK_transfer_users_receiver_user_id",
                        column: x => x.receiver_user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transfer_users_sender_user_id",
                        column: x => x.sender_user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transfer_receiver_user_id",
                table: "transfer",
                column: "receiver_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transfer_sender_user_id",
                table: "transfer",
                column: "sender_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transfer");
        }
    }
}
