using coreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serviceLayer.Users
{
    public interface IUser
    {
        int addUser(User user);
        List<User> findAll();
        User findById(int id);
        int addRoletoUser(int idu,int idr);
    }
}
