using Microsoft.EntityFrameworkCore.Migrations;

namespace ReadyTask.Migrations
{
    public partial class AddedProfileImageName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileImageName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "83d3fa4e-2410-4d9b-9e7e-9d82f35db761");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "eccdbafa-ee79-4b45-9571-3dbebed1764a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "46b946fb-88af-48fa-a0ae-8bdc8f7b7bfc");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae0f8a11-d52f-4e3b-84aa-06155595ce99", "AQAAAAEAACcQAAAAEJI6eVyWppFmj+I/Bw9r1pnag6O9k21Q547msj6AUYz2HaFQxtBcg2UHPKrunwd9og==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImageName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "eb458f6c-0afb-4186-ba83-78ef40317e77");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "c4d96c34-b3c1-4070-9d99-59b83bca7db7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "e953afee-072f-4e9e-8832-ebc163bc254b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 100,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "827fc347-ea92-4cdb-ad6e-f449ace4b435", "AQAAAAEAACcQAAAAEPuTT0ki2YTaI9HLMtlFjUKJFj3Ozk1ONtQOEA1XtFGLauSxKIk++ZHwu4TeLVih9w==" });
        }
    }
}
