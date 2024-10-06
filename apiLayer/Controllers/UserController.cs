using coreLayer;
using Microsoft.AspNetCore.Mvc;
using serviceLayer.Users;

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
        public IEnumerable<User> Get()
        {
            return _userService.findAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _userService.findById(id);
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
