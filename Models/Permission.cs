using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Permission
    {
        public Permission()
        {
            UserPermissionDevices = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserPermissionDevice> UserPermissionDevices { get; set; }
    }
}
