using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Exceptions;

namespace api.Models
{
    public partial class IotHomeControlContext : DbContext
    {
        public IotHomeControlContext()
        {
        }

        public IotHomeControlContext(DbContextOptions<IotHomeControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<DeviceType> DeviceType { get; set; }
        public virtual DbSet<Family> Family { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserPermissionDevice> UserPermissionDevice { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw (new MisconfiguredDatabaseConnectionException());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.HasIndex(e => e.DeviceTypeId)
                    .HasName("device_type_id");

                entity.HasIndex(e => e.ExternalId)
                    .HasName("external_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeviceTypeId).HasColumnName("device_type_id");

                entity.Property(e => e.ExternalId)
                    .IsRequired()
                    .HasColumnName("external_id")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.DeviceType)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.DeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device_ibfk_1");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("device_type");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("family");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MainUserId).HasColumnName("main_user_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasName("email")
                    .IsUnique();

                entity.HasIndex(e => e.FamilyId)
                    .HasName("family_id");

                entity.HasIndex(e => e.RolId)
                    .HasName("rol_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FamilyId).HasColumnName("family_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Family)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.FamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_2");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");
            });

            modelBuilder.Entity<UserPermissionDevice>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId, e.DeviceId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

                entity.ToTable("user_permission_device");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("device_id");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.UserPermissionDevice)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_3");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissionDevice)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissionDevice)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_1");
            });

            modelBuilder.Seed();
            modelBuilder.SeedTestData();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
