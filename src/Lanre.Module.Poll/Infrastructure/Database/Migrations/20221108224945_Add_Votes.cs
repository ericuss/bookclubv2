using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanre.Module.Poll.Infrastructure.Database.Migrations
{
    public partial class Add_Votes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Votes",
                schema: "Poll",
                columns: table => new
                {
                    VoteListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Voted = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Readed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blocked = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => new { x.VoteListId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Votes_VoteList_VoteListId",
                        column: x => x.VoteListId,
                        principalSchema: "Poll",
                        principalTable: "VoteList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Votes",
                schema: "Poll");
        }
    }
}
