using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Device
    {
        public Device()
        {
            InverseDeviceTypeNavigation = new HashSet<Device>();
            UserPermissionDevice = new HashSet<UserPermissionDevice>();
        }

        public uint Id { get; set; }
        public uint ExternalId { get; set; }
        public uint DeviceType { get; set; }

        public virtual Device DeviceTypeNavigation { get; set; }
        public virtual ICollection<Device> InverseDeviceTypeNavigation { get; set; }
        public virtual ICollection<UserPermissionDevice> UserPermissionDevice { get; set; }
    }
}
