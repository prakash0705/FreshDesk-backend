using Microsoft.EntityFrameworkCore.Migrations;

namespace FreshDesk.Entities.Migrations
{
    public partial class newserverdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Registers_registerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Registers_registerId",
                table: "Log");

            migrationBuilder.DropForeignKey(
                name: "FK_Log_Tickets_ticketId",
                table: "Log");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Log");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Log",
                newName: "Logs");

            migrationBuilder.RenameIndex(
                name: "IX_Log_ticketId",
                table: "Logs",
                newName: "IX_Logs_ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_Log_registerId",
                table: "Logs",
                newName: "IX_Logs_registerId");

            migrationBuilder.AlterColumn<int>(
                name: "registerId",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Mobile",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "Logs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Registers_registerId",
                table: "Contacts",
                column: "registerId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Registers_registerId",
                table: "Logs",
                column: "registerId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Tickets_ticketId",
                table: "Logs",
                column: "ticketId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Registers_registerId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Registers_registerId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Tickets_ticketId",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "Log");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ticketId",
                table: "Log",
                newName: "IX_Log_ticketId");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_registerId",
                table: "Log",
                newName: "IX_Log_registerId");

            migrationBuilder.AlterColumn<int>(
                name: "registerId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Mobile",
                table: "Contacts",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ticketId",
                table: "Log",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Log",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Registers_registerId",
                table: "Contacts",
                column: "registerId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
