using Membership.Components.Interfaces;
using Membership.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Membership.Components.Implementations
{
    public class UserRepository : IUserRepository
    {
        protected MembershipContext ctx;

        public UserRepository(MembershipContext ctx)
        {
            this.ctx = ctx;
        }

        public bool RegisterUser(string username, string email, string password, int roleId)
        {
            if (!ctx.Users.Any(m => m.Username == username || m.Email == email))
            {
                var user = new User()
                {
                    Username = username,
                    Email = email,
                    Password = password.GetMD5(),
                    LastLoginDate = DateTime.UtcNow,
                };

                user.Roles = new List<Role>();
                user.Roles.Add(ctx.Roles.Find(roleId));

                ctx.Users.Add(user);

                try
                {
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                }
            }

            return false;
        }


        public bool ValidateUser(string login, string password)
        {
            var user = ctx.Users.First(m => (m.Username == login || m.Email == login));
            var isValid = user.Password == password.GetMD5();

            if (isValid)
            {
                user.LastLoginDate = DateTime.UtcNow;
                ctx.Entry(user).State = EntityState.Modified;

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                    // or just trow an exeption to show it to the user
                }
            }

            return isValid;
        }
        
        public bool IsInRole(string login, string roleName)
        {
            var user = ctx.Users.First(m => (m.Username == login || m.Email == login));

            if (user != null)
            {
                return user.Roles.Any(m => m.Name == roleName);
            }

            return false;
        }
    }
}