using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Rol
    {
        public const string ROLE_PARENT = "ROLE_PARENT";

        public Rol()
        {
            User = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }

        public bool isParent()
        {
            return this.Name == Rol.ROLE_PARENT;
        }
    }
}
