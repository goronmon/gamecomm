using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameComm.Data.Migrations
{
    public partial class InitialBacklog_Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ConsoleSystems_ConsoleSystemId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ConsoleSystemId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SystemId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastMofieidDate",
                table: "Games",
                newName: "LastModifidDate");

            migrationBuilder.AlterColumn<long>(
                name: "ConsoleSystemId",
                table: "Games",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsoleSystemId1",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ConsoleSystemId1",
                table: "Games",
                column: "ConsoleSystemId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ConsoleSystems_ConsoleSystemId1",
                table: "Games",
                column: "ConsoleSystemId1",
                principalTable: "ConsoleSystems",
                principalColumn: "ConsoleSystemId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ConsoleSystems_ConsoleSystemId1",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_ConsoleSystemId1",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ConsoleSystemId1",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "LastModifidDate",
                table: "Games",
                newName: "LastMofieidDate");

            migrationBuilder.AlterColumn<int>(
                name: "ConsoleSystemId",
                table: "Games",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "SystemId",
                table: "Games",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Games_ConsoleSystemId",
                table: "Games",
                column: "ConsoleSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ConsoleSystems_ConsoleSystemId",
                table: "Games",
                column: "ConsoleSystemId",
                principalTable: "ConsoleSystems",
                principalColumn: "ConsoleSystemId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
