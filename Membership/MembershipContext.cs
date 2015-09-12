using Membership.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Membership
{
    public class MembershipContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.ValidateOnSaveEnabled = false;
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasMany(m => m.Roles).WithMany(m => m.Users).Map(m => { m.MapLeftKey("UserId"); m.MapRightKey("RoleId"); m.ToTable("Users2Roles"); });
        }
    }
}