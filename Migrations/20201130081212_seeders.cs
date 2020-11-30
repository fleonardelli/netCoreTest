using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seeders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "device_type",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1u, "Thermostat" },
                    { 2u, "Door" }
                });

            migrationBuilder.InsertData(
                table: "permission",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1u, "LOCK" },
                    { 2u, "UNLOCK" },
                    { 3u, "REQUEST_UNLOCK" },
                    { 4u, "REQUEST_LOCK" }
                });

            migrationBuilder.InsertData(
                table: "rol",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1u, "ROL_USER" },
                    { 2u, "ROL_CHILDREN" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "device_type",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "device_type",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 3u);

            migrationBuilder.DeleteData(
                table: "permission",
                keyColumn: "id",
                keyValue: 4u);

            migrationBuilder.DeleteData(
                table: "rol",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "rol",
                keyColumn: "id",
                keyValue: 2u);
        }
    }
}
