using coreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer.Roles
{
    public interface IRole
    {
        int AddRole(Role role);
        Role FindRoleById(int roleId);
        List<Role> AllRoles();

    }
}
