using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            UserPermissionDevice = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public uint RolId { get; set; }
        public uint FamilyId { get; set; }
        [NotMapped]
        public string token { get; set; }

        public virtual Family Family { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<UserPermissionDevice> UserPermissionDevice { get; set; }
    }
}
