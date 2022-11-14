using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanre.Module.Poll.Infrastructure.Database.Migrations
{
    public partial class Add_Created_To_VoteList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Created",
                schema: "Poll",
                table: "VoteList",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: DateTimeOffset.Now);

            migrationBuilder.UpdateData(
                schema: "Poll",
                table: "VoteList",
                keyColumn: "Id",
                keyValue: new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
                column: "Created",
                value: DateTimeOffset.Now);

            migrationBuilder.UpdateData(
                schema: "Poll",
                table: "VoteList",
                keyColumn: "Id",
                keyValue: new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"),
                column: "Created",
                value: DateTimeOffset.Now);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Poll",
                table: "VoteList");
        }
    }
}
