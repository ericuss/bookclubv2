using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanre.Module.Poll.Infrastructure.Database.Migrations
{
    public partial class Add_NumberOfVotes_In_VoteList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfVotes",
                schema: "Poll",
                table: "VoteList",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                schema: "Poll",
                table: "VoteList",
                keyColumn: "Id",
                keyValue: new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"),
                column: "NumberOfVotes",
                value: 2);

            migrationBuilder.UpdateData(
                schema: "Poll",
                table: "VoteList",
                keyColumn: "Id",
                keyValue: new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"),
                column: "NumberOfVotes",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfVotes",
                schema: "Poll",
                table: "VoteList");
        }
    }
}
