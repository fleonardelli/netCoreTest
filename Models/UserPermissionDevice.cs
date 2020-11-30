using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class UserPermissionDevice
    {
        public uint UserId { get; set; }
        public uint PermissionId { get; set; }
        public uint DeviceId { get; set; }

        public virtual Device Device { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}
