using coreLayer;
using dataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer.Roles
{
    public class RolesService : IRole
    {
        UserContext _context;

        public RolesService(UserContext context)
        {
            _context = context;
        }

        public int AddRole(Role role)
        {
            _context.roles.Add(role);
            int nb = _context.SaveChanges();
            return nb;
        }

        public List<Role> AllRoles()
        {
            return _context.roles.Include(r=>r.Users).ToList();
        }

        public Role FindRoleById(int roleId)
        {
            return _context.roles.Include(r => r.Users).FirstOrDefault(rr=>rr.Id ==roleId);
        }
    }
}
