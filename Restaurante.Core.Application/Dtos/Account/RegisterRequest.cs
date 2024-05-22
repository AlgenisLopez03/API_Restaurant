

namespace Restaurante.Core.Application.Dtos.Account
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
