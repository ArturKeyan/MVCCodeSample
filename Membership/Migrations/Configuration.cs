namespace Membership.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Membership.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<Membership.MembershipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Membership.MembershipContext ctx)
        {
            ctx.Roles.AddOrUpdate(m => m.Name,
                new Role()
                {
                    Name = "Guest"
                },
                new Role() 
                {
                    Name = "Moderator"
                },
                new Role()
                {
                    Name = "Administrator"
                }
            );
        }
    }
}
