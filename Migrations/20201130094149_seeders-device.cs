using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seedersdevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "device",
                columns: new[] { "id", "device_type_id", "external_id" },
                values: new object[] { 1u, 1u, "000x123asd213" });

            migrationBuilder.UpdateData(
                table: "family",
                keyColumn: "id",
                keyValue: 1u,
                column: "main_user_id",
                value: 1u);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "device",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.UpdateData(
                table: "family",
                keyColumn: "id",
                keyValue: 1u,
                column: "main_user_id",
                value: 0u);
        }
    }
}
