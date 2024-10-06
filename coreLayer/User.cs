using coreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace coreLayer
{
    public class User
    {
        int id;
        Role? rl;
        string name;
        string password;

        public int Id { get => id; set => id = value; }
        public Role? Rl { get => rl; set => rl = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
    }
}
