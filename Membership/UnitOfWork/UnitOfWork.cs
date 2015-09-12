using Membership.Components.Implementations;
using Membership.Components.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace Membership.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private MembershipContext ctx { get; set; }
            
        public UnitOfWork()
        {
            ctx = new MembershipContext();
        }
        
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;

        public IUserRepository UserRepository
        {
            get { return userRepository ?? (userRepository = new UserRepository(ctx)); }
        }

        public IRoleRepository RoleRepository
        {
            get { return roleRepository ?? (roleRepository = new RoleRepository(ctx)); }
        }

        #region Dispose
        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    ctx.Dispose();
                }
            }

            disposed = true;
        }
        #endregion Dispose
    }
}