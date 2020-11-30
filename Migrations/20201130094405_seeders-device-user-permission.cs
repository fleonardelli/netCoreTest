using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seedersdeviceuserpermission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user_permission_device",
                columns: new[] { "user_id", "permission_id", "device_id" },
                values: new object[,]
                {
                    { 1u, 1u, 1u },
                    { 1u, 2u, 1u },
                    { 2u, 3u, 1u },
                    { 2u, 4u, 1u }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user_permission_device",
                keyColumns: new[] { "user_id", "permission_id", "device_id" },
                keyValues: new object[] { 1u, 1u, 1u });

            migrationBuilder.DeleteData(
                table: "user_permission_device",
                keyColumns: new[] { "user_id", "permission_id", "device_id" },
                keyValues: new object[] { 1u, 2u, 1u });

            migrationBuilder.DeleteData(
                table: "user_permission_device",
                keyColumns: new[] { "user_id", "permission_id", "device_id" },
                keyValues: new object[] { 2u, 3u, 1u });

            migrationBuilder.DeleteData(
                table: "user_permission_device",
                keyColumns: new[] { "user_id", "permission_id", "device_id" },
                keyValues: new object[] { 2u, 4u, 1u });
        }
    }
}
