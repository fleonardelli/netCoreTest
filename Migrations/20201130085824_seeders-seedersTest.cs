﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class seedersseedersTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "device",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    external_id = table.Column<uint>(nullable: false),
                    device_type = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device", x => x.id);
                    table.ForeignKey(
                        name: "device_ibfk_1",
                        column: x => x.device_type,
                        principalTable: "device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "device_type",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "family",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    surname = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    main_user_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_family", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(100)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<uint>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    surname = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    email = table.Column<string>(type: "varchar(150)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_0900_ai_ci"),
                    rol_id = table.Column<uint>(nullable: false),
                    family_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "user_ibfk_2",
                        column: x => x.family_id,
                        principalTable: "family",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_ibfk_1",
                        column: x => x.rol_id,
                        principalTable: "rol",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user_permission_device",
                columns: table => new
                {
                    user_id = table.Column<uint>(nullable: false),
                    permission_id = table.Column<uint>(nullable: false),
                    device_id = table.Column<uint>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.user_id, x.permission_id, x.device_id })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });
                    table.ForeignKey(
                        name: "user_permission_device_ibfk_3",
                        column: x => x.device_id,
                        principalTable: "device",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_permission_device_ibfk_2",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "user_permission_device_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                values: new object[] { 1u, 1u, "Thompson" });

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

            migrationBuilder.CreateIndex(
                name: "device_type",
                table: "device",
                column: "device_type");

            migrationBuilder.CreateIndex(
                name: "external_id",
                table: "device",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name",
                table: "device_type",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name",
                table: "permission",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name",
                table: "rol",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "email",
                table: "user",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "family_id",
                table: "user",
                column: "family_id");

            migrationBuilder.CreateIndex(
                name: "rol_id",
                table: "user",
                column: "rol_id");

            migrationBuilder.CreateIndex(
                name: "device_id",
                table: "user_permission_device",
                column: "device_id");

            migrationBuilder.CreateIndex(
                name: "permission_id",
                table: "user_permission_device",
                column: "permission_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_type");

            migrationBuilder.DropTable(
                name: "user_permission_device");

            migrationBuilder.DropTable(
                name: "device");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "family");

            migrationBuilder.DropTable(
                name: "rol");
        }
    }
}
