using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class changing_data_seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1u,
                column: "email",
                value: "parent@gmail.com");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2u,
                column: "email",
                value: "kid@gmail.com");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 1u,
                column: "email",
                value: "fer@gmail.com");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id",
                keyValue: 2u,
                column: "email",
                value: "flor@gmail.com");
        }
    }
}
