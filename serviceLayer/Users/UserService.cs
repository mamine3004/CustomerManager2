using coreLayer;
using dataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer.Users
{
    public class UserService : IUser
    {
        UserContext _context;

        public UserService(UserContext context)
        {
            _context = context;
        }

        public int addRoletoUser(int idu, int idr)
        {
            User u = _context.users.Find(idu);
            Role r = _context.roles.Find(idr);
            if (r != null)
            {
                if (u !=null)
                {
                    u.Rl = r;
                    int nb = _context.SaveChanges();
                    return nb;
                }
            }
            return -1;
        }

        public int addUser(User user)
        {
            _context.users.Add(user);
            int nb = _context.SaveChanges();
            return nb;
        }

        public List<User> findAll()
        {
            return _context.users.Include(u => u.Rl).ToList();
        }

        public User findById(int id)
        {
            User u = _context.users.Include(u => u.Rl).FirstOrDefault(u=>u.Id==id);
            return u;
        }
    }
}
