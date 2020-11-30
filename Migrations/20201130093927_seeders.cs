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
                table: "family",
                columns: new[] { "id", "main_user_id", "surname" },
                values: new object[] { 1u, 0u, "Thompson" });

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

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "family_id", "name", "rol_id", "surname" },
                values: new object[] { 1u, "fer@gmail.com", 1u, "Fernando", 1u, "Leonardelli" });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id", "email", "family_id", "name", "rol_id", "surname" },
                values: new object[] { 2u, "flor@gmail.com", 1u, "Florencia", 2u, "Leonardelli" });
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
                table: "user",
                keyColumn: "id",
                keyValue: 1u);

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "id",
                keyValue: 2u);

            migrationBuilder.DeleteData(
                table: "family",
                keyColumn: "id",
                keyValue: 1u);

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
