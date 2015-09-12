using Membership.Components.Interfaces;
using Membership.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Membership.Components.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        protected MembershipContext ctx;

        public RoleRepository(MembershipContext ctx)
        {
            this.ctx = ctx;
        }
        
        public IEnumerable<Role> GetAll()
        {
            return ctx.Roles;
        }
    }
}