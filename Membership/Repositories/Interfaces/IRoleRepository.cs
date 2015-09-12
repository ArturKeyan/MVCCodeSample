using Membership.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership.Components.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
    }
}
