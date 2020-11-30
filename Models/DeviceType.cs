using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Device = new HashSet<Device>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
