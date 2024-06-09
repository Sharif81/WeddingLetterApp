using Microsoft.EntityFrameworkCore.Migrations;

namespace WeddingLetter.Migrations
{
    public partial class Programtableupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_Events_EventsId",
                table: "Program");

            migrationBuilder.DropIndex(
                name: "IX_Program_EventsId",
                table: "Program");

            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "Program");

            migrationBuilder.CreateIndex(
                name: "IX_Program_EventId",
                table: "Program",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Events_EventId",
                table: "Program",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Program_Events_EventId",
                table: "Program");

            migrationBuilder.DropIndex(
                name: "IX_Program_EventId",
                table: "Program");

            migrationBuilder.AddColumn<int>(
                name: "EventsId",
                table: "Program",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Program_EventsId",
                table: "Program",
                column: "EventsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Events_EventsId",
                table: "Program",
                column: "EventsId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
