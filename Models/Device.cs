using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Device
    {
        public Device()
        {
            UserPermissionDevice = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public string ExternalId { get; set; }
        public uint DeviceTypeId { get; set; }

        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<UserPermissionDevice> UserPermissionDevice { get; set; }
    }
}
