﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Models;

namespace api.Migrations
{
    [DbContext(typeof(IotHomeControlContext))]
    [Migration("20201130081212_seeders")]
    partial class seeders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("api.Models.Device", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("DeviceType")
                        .HasColumnName("device_type")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("ExternalId")
                        .HasColumnName("external_id")
                        .HasColumnType("int unsigned");

                    b.HasKey("Id");

                    b.HasIndex("DeviceType")
                        .HasName("device_type");

                    b.HasIndex("ExternalId")
                        .IsUnique()
                        .HasName("external_id");

                    b.ToTable("device");
                });

            modelBuilder.Entity("api.Models.DeviceType", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("name");

                    b.ToTable("device_type");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Name = "Thermostat"
                        },
                        new
                        {
                            Id = 2u,
                            Name = "Door"
                        });
                });

            modelBuilder.Entity("api.Models.Family", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("MainUserId")
                        .HasColumnName("main_user_id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("Id");

                    b.HasIndex("MainUserId")
                        .HasName("main_user_id");

                    b.ToTable("family");
                });

            modelBuilder.Entity("api.Models.Permission", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("name");

                    b.ToTable("permission");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Name = "LOCK"
                        },
                        new
                        {
                            Id = 2u,
                            Name = "UNLOCK"
                        },
                        new
                        {
                            Id = 3u,
                            Name = "REQUEST_UNLOCK"
                        },
                        new
                        {
                            Id = 4u,
                            Name = "REQUEST_LOCK"
                        });
                });

            modelBuilder.Entity("api.Models.Rol", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("varchar(50)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("name");

                    b.ToTable("rol");

                    b.HasData(
                        new
                        {
                            Id = 1u,
                            Name = "ROL_USER"
                        },
                        new
                        {
                            Id = 2u,
                            Name = "ROL_CHILDREN"
                        });
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.Property<uint>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.Property<uint>("RolId")
                        .HasColumnName("rol_id")
                        .HasColumnType("int unsigned");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasColumnType("varchar(150)")
                        .HasAnnotation("MySql:CharSet", "utf8mb4")
                        .HasAnnotation("MySql:Collation", "utf8mb4_0900_ai_ci");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("email");

                    b.HasIndex("RolId")
                        .HasName("rol_id");

                    b.ToTable("user");
                });

            modelBuilder.Entity("api.Models.UserPermissionDevice", b =>
                {
                    b.Property<uint>("UserId")
                        .HasColumnName("user_id")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("PermissionId")
                        .HasColumnName("permission_id")
                        .HasColumnType("int unsigned");

                    b.Property<uint>("DeviceId")
                        .HasColumnName("device_id")
                        .HasColumnType("int unsigned");

                    b.HasKey("UserId", "PermissionId", "DeviceId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                    b.HasIndex("DeviceId")
                        .HasName("device_id");

                    b.HasIndex("PermissionId")
                        .HasName("permission_id");

                    b.ToTable("user_permission_device");
                });

            modelBuilder.Entity("api.Models.Device", b =>
                {
                    b.HasOne("api.Models.Device", "DeviceTypeNavigation")
                        .WithMany("InverseDeviceTypeNavigation")
                        .HasForeignKey("DeviceType")
                        .HasConstraintName("device_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.Family", b =>
                {
                    b.HasOne("api.Models.User", "MainUser")
                        .WithMany("Family")
                        .HasForeignKey("MainUserId")
                        .HasConstraintName("family_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.User", b =>
                {
                    b.HasOne("api.Models.Rol", "Rol")
                        .WithMany("User")
                        .HasForeignKey("RolId")
                        .HasConstraintName("user_ibfk_1")
                        .IsRequired();
                });

            modelBuilder.Entity("api.Models.UserPermissionDevice", b =>
                {
                    b.HasOne("api.Models.Device", "Device")
                        .WithMany("UserPermissionDevice")
                        .HasForeignKey("DeviceId")
                        .HasConstraintName("user_permission_device_ibfk_3")
                        .IsRequired();

                    b.HasOne("api.Models.Permission", "Permission")
                        .WithMany("UserPermissionDevice")
                        .HasForeignKey("PermissionId")
                        .HasConstraintName("user_permission_device_ibfk_2")
                        .IsRequired();

                    b.HasOne("api.Models.User", "User")
                        .WithMany("UserPermissionDevice")
                        .HasForeignKey("UserId")
                        .HasConstraintName("user_permission_device_ibfk_1")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
