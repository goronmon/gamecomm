using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameComm.Data.Migrations
{
    public partial class InitialBacklog_Fixes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModifidDate",
                table: "Games",
                newName: "LastModified");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastModified",
                table: "Games",
                newName: "LastModifidDate");
        }
    }
}
