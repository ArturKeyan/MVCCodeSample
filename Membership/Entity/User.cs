using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Membership.Entity
{
    [Table("Users")]
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LastLoginDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }   
}