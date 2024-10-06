using coreLayer;
using Microsoft.AspNetCore.Mvc;
using serviceLayer.Roles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRole _roleService;

        public RoleController(IRole roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _roleService.AllRoles();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return _roleService.FindRoleById(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Post([FromBody] Role role)
        {
            _roleService.AddRole(role);
        }

        //// PUT api/<RoleController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RoleController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
