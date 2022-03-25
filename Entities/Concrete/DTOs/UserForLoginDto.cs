

using Entities.Abstract.Interface;

namespace Entities.Concrete.DTOs
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
