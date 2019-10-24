using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyTask.Migrations
{
    public partial class AddedStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TaskItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b204c1dd-e23b-4fd2-a203-a0a72fefa168", "AQAAAAEAACcQAAAAEE2D7OlXmysa2ag9F6YtVbOyUNO+MM8ptRMr0g632fLMqNqOW0QkI+o8LvjP36tUEg==" });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "StatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 102,
                column: "StatusId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TaskItems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a0996b4-3d38-437b-a1c1-772443557dd2", "AQAAAAEAACcQAAAAEEaKU4GOszzVoKUjQzvnld5gPnO8l3c6jEQwnMr6JICs6yzymn+i9vEOSrLukBsRPA==" });
        }
    }
}
