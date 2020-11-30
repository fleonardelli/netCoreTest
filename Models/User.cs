using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public partial class User
    {
        public User()
        {
            UserPermissionDevice = new HashSet<UserPermissionDevice>();
        }

        [Key]
        public uint Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Surname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public uint RolId { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public uint FamilyId { get; set; }

        [NotMapped]
        public string token { get; set; }

        public virtual Family Family { get; set; }
        public virtual Rol Rol { get; set; }
        public virtual ICollection<UserPermissionDevice> UserPermissionDevice { get; set; }
    }
}
