using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class Family
    {
        public Family()
        {
            User = new HashSet<User>();
        }

        public uint Id { get; set; }
        public string Surname { get; set; }
        public uint MainUserId { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
