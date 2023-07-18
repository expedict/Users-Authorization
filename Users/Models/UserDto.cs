using System.Security;

namespace Users.Models
{
    public class UserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
