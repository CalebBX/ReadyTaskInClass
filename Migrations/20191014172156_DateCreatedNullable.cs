using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyTask.Migrations
{
    public partial class DateCreatedNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TaskReplies",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0a0996b4-3d38-437b-a1c1-772443557dd2", "AQAAAAEAACcQAAAAEEaKU4GOszzVoKUjQzvnld5gPnO8l3c6jEQwnMr6JICs6yzymn+i9vEOSrLukBsRPA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "TaskReplies",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "73a0d41e-33af-4e4b-9f8f-fabac2244ed3", "AQAAAAEAACcQAAAAEILQbTGhtjqtH5PVSQqBhFipeQoYD3ELwa01QntYgx1x5GhPybdW0dUauGUFnbhHqw==" });
        }
    }
}
