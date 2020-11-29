using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Permissions
    {
        public Permissions()
        {
            UserPermissionDevice = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserPermissionDevice> UserPermissionDevice { get; set; }
    }
}
