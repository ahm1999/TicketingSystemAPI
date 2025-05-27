namespace TicketingSystem.Shared.Utils
{
    public interface IPasswordHashing
    {
        string HashPassword(string password);

        bool ValidatePassword(string passwordHash, string inputPassword);
    }
}
