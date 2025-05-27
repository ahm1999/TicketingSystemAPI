
using BC = BCrypt.Net.BCrypt;

namespace TicketingSystem.Shared.Utils
{
    public class PasswordHashing : IPasswordHashing
    {

        public string HashPassword(string password)
        {
            var passwordHash = BC.HashPassword(password);
            return passwordHash;

        }

        public bool ValidatePassword(string passwordHash, string inputPassword)
        {
            return BC.Verify(inputPassword, passwordHash);
        }
    }
}
