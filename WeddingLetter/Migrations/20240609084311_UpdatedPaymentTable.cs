using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingLetter.Migrations
{
    public partial class UpdatedPaymentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Events_EventId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EventId",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Payments_EventId",
                table: "Payments",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Events_EventId",
                table: "Payments",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
