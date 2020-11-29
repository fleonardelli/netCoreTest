using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            Families = new HashSet<Family>();
            UserPermissionDevices = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public uint RolId { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<UserPermissionDevice> UserPermissionDevices { get; set; }
    }
}
