using apiLayer.Dto.Roles;
using apiLayer.Dto.Users;
using coreLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serviceLayer.Roles;
using serviceLayer.Users;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser  _userService;

        public UserController(IUser userService)
        {
            this._userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<UserWithRoleDto> Get()
        {
            return _userService.findAll()
                .Select(u => new UserWithRoleDto
                        {
                            Id = u.Id,
                            Name = u.Name,
                            Password = u.Password,
                            role = u.Rl!=null?new RoleOfUserDto
                            {
                                Id = u.Rl.Id,
                                Name = u.Rl.Name
                            }:null,
                }).ToList();

        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserWithRoleDto? Get(int id)
        {
            User u = _userService.findById(id);
            if (u!=null)
            {
                UserWithRoleDto user = new UserWithRoleDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Password = u.Password,
                    role = u.Rl != null ? new RoleOfUserDto
                    {
                        Id = u.Rl.Id,
                        Name = u.Rl.Name
                    } : null,

                };
                return user;

            }
            return null;
        }

        // POST api/<UserController>
        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            _userService.addUser(user);

        }
        [HttpPost("{idUser}/role/{idRole}")]
        public int AddRoleToUser(int idRole,int idUser)
        {
           int nb = _userService.addRoletoUser(idUser,idRole);
            return nb;
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
