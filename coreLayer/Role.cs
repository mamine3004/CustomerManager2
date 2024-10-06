using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace coreLayer
{
    public class Role
    {
        int id;
        String name;
        [JsonIgnore]
        List<User>? users = new List<User>();

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<User>? Users { get => users; set => users = value; }
    }
}
