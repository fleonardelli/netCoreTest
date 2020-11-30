using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(
                new Rol {Id = 1, Name = "ROL_USER"},
                new Rol {Id = 2, Name = "ROL_CHILDREN"}
            );

            modelBuilder.Entity<Permission>().HasData(
                new Permission {Id =1, Name = "LOCK"},
                new Permission {Id =2, Name = "UNLOCK"},
                new Permission {Id =3, Name = "REQUEST_UNLOCK"},
                new Permission {Id =4, Name = "REQUEST_LOCK"}
            );

            modelBuilder.Entity<DeviceType>().HasData(
                new DeviceType {Id = 1, Name = "Thermostat"},
                new DeviceType {Id = 2, Name = "Door"}
            );
        }
    }
}