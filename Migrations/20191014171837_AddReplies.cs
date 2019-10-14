using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyTask.Migrations
{
    public partial class AddReplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskReplies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    ReadyTaskUserId = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    TaskItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskReplies_AspNetUsers_ReadyTaskUserId",
                        column: x => x.ReadyTaskUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskReplies_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73a0d41e-33af-4e4b-9f8f-fabac2244ed3", "AQAAAAEAACcQAAAAEILQbTGhtjqtH5PVSQqBhFipeQoYD3ELwa01QntYgx1x5GhPybdW0dUauGUFnbhHqw==" });

            migrationBuilder.CreateIndex(
                name: "IX_TaskReplies_ReadyTaskUserId",
                table: "TaskReplies",
                column: "ReadyTaskUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskReplies_TaskItemId",
                table: "TaskReplies",
                column: "TaskItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskReplies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1b06a7b-47b6-40a9-8dd4-99bbc506a757", "AQAAAAEAACcQAAAAEMxxUIAK5P838pkbx+Km6hGlFZWHIjvBKGI3v6V3RCc0jds1NzeSyJtQlPnbxl1KCw==" });
        }
    }
}
