using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshDesk.Entities.Migrations
{
    public partial class Addinglogtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Registers_registerId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Tickets_ticketId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "Log",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "registerId",
                table: "Log",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Registers_registerId",
                table: "Log",
                column: "registerId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Tickets_ticketId",
                table: "Log",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Registers_registerId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Tickets_ticketId",
                table: "Log");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "Log",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "registerId",
                table: "Log",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Registers_registerId",
                table: "Log",
                column: "registerId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Tickets_ticketId",
                table: "Log",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
