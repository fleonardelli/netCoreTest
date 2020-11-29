using System;
using System.Collections.Generic;

#nullable disable

namespace api.Models
{
    public partial class Family
    {
        public uint Id { get; set; }
        public string Surname { get; set; }
        public uint MainUserId { get; set; }

        public virtual User MainUser { get; set; }
    }
}
