using apiLayer.Dto.Roles;
using apiLayer.Dto.Users;
using coreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serviceLayer.Roles;
using System.Data;

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
        public IEnumerable<RoleDto> Get()
        {
            return _roleService.AllRoles()
                        .Select(r => new RoleDto
                        {
                            Id = r.Id,
                            Name = r.Name,
                            Users = r.Users.Select(u => new UserDto
                            {
                                Id = u.Id,
                                Name = u.Name,
                                Password = u.Password
                            }).ToList()
                        })
                        .ToList();

        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public RoleDto? Get(int id)
        {
            Role r = _roleService.FindRoleById(id);
            if (r != null)
            {

            RoleDto rl = new RoleDto
            {
                Id = r.Id,
                Name = r.Name,
                Users = r.Users.Select(u => new UserDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Password = u.Password
                }).ToList()
            };
            return rl;
            }
            return null;
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
