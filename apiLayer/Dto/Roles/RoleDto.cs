using apiLayer.Dto.Users;

namespace apiLayer.Dto.Roles
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto>? Users { get; set; }
    }
}
