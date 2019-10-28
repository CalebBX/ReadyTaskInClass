using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyTask.Migrations
{
    public partial class SeedUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "eb458f6c-0afb-4186-ba83-78ef40317e77", "Admin", "ADMIN" },
                    { 2, "c4d96c34-b3c1-4070-9d99-59b83bca7db7", "Manager", "MANAGER" },
                    { 3, "e953afee-072f-4e9e-8832-ebc163bc254b", "Dev", "DEV" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "827fc347-ea92-4cdb-ad6e-f449ace4b435", "user@test.com", "USER@TEST.COM", "USER@TEST.COM", "AQAAAAEAACcQAAAAEPuTT0ki2YTaI9HLMtlFjUKJFj3Ozk1ONtQOEA1XtFGLauSxKIk++ZHwu4TeLVih9w==", "user@test.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 1, "eb458f6c-0afb-4186-ba83-78ef40317e77" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 2, "c4d96c34-b3c1-4070-9d99-59b83bca7db7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 3, "e953afee-072f-4e9e-8832-ebc163bc254b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "UserName" },
                values: new object[] { "b204c1dd-e23b-4fd2-a203-a0a72fefa168", "test@test.com", "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEE2D7OlXmysa2ag9F6YtVbOyUNO+MM8ptRMr0g632fLMqNqOW0QkI+o8LvjP36tUEg==", "test@test.com" });
        }
    }
}
