using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanre.Module.Poll.Infrastructure.Database.Migrations
{
    public partial class Add_Book_VoteList_Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BooksOfVoteList",
                schema: "Poll",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VoteListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Votes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloquedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksOfVoteList", x => new { x.BookId, x.VoteListId });
                    table.ForeignKey(
                        name: "FK_BooksOfVoteList_Books_BookId",
                        column: x => x.BookId,
                        principalSchema: "library",
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooksOfVoteList_VoteList_VoteListId",
                        column: x => x.VoteListId,
                        principalSchema: "Poll",
                        principalTable: "VoteList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Poll",
                table: "BooksOfVoteList",
                columns: new[] { "BookId", "VoteListId", "BloquedBy", "ReadedBy", "Votes" },
                values: new object[] { new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"), new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"), "", "", "" });

            migrationBuilder.InsertData(
                schema: "Poll",
                table: "BooksOfVoteList",
                columns: new[] { "BookId", "VoteListId", "BloquedBy", "ReadedBy", "Votes" },
                values: new object[] { new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"), new Guid("332fb5ab-2eab-4393-a920-9b46faed3cb5"), "", "", "" });

            migrationBuilder.InsertData(
                schema: "Poll",
                table: "BooksOfVoteList",
                columns: new[] { "BookId", "VoteListId", "BloquedBy", "ReadedBy", "Votes" },
                values: new object[] { new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"), new Guid("8bddba00-f200-402d-b45b-6f1634a5f622"), "", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_BooksOfVoteList_VoteListId",
                schema: "Poll",
                table: "BooksOfVoteList",
                column: "VoteListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksOfVoteList",
                schema: "Poll");
        }
    }
}
