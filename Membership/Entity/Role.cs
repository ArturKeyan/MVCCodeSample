using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Membership.Entity
{
    [Table("Roles")]
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}