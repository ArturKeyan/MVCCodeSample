using Membership.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Components.Interfaces
{
    public interface IUserRepository
    {
        bool RegisterUser(string username, string email, string password, int roleId);
        bool ValidateUser(string login, string password);
        bool IsInRole(string login, string roleName);
    }
}
