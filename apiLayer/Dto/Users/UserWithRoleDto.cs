using apiLayer.Dto.Roles;

namespace apiLayer.Dto.Users
{
    public class UserWithRoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public RoleOfUserDto? role { get; set; }

    }
}
