using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Rol
    {
        public Rol()
        {
            User = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
