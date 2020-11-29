using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class iot_home_controlContext : DbContext
    {
        public iot_home_controlContext()
        {
        }

        public iot_home_controlContext(DbContextOptions<iot_home_controlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPermissionDevice> UserPermissionDevices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=iot_home_control;user=root;password=12345678", x => x.ServerVersion("8.0.19-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("device");

                entity.HasIndex(e => e.DeviceType, "device_type");

                entity.HasIndex(e => e.ExternalId, "external_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeviceType).HasColumnName("device_type");

                entity.Property(e => e.ExternalId).HasColumnName("external_id");

                entity.HasOne(d => d.DeviceTypeNavigation)
                    .WithMany(p => p.InverseDeviceTypeNavigation)
                    .HasForeignKey(d => d.DeviceType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("device_ibfk_1");
            });

            modelBuilder.Entity<DeviceType>(entity =>
            {
                entity.ToTable("device_type");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.ToTable("family");

                entity.HasIndex(e => e.MainUserId, "main_user_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MainUserId).HasColumnName("main_user_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("surname")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.MainUser)
                    .WithMany(p => p.Families)
                    .HasForeignKey(d => d.MainUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("family_ibfk_1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol");

                entity.HasIndex(e => e.Name, "name")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email, "email")
                    .IsUnique();

                entity.HasIndex(e => e.RolId, "rol_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("email")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("name")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasColumnName("surname")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Users)
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

                entity.HasIndex(e => e.DeviceId, "device_id");

                entity.HasIndex(e => e.PermissionId, "permission_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.UserPermissionDevices)
                    .HasForeignKey(d => d.DeviceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_3");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissionDevices)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissionDevices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_permission_device_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
