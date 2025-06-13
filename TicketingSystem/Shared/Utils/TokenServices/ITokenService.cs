using TicketingSystem.Features.AuthUserFeature;

namespace TicketingSystem.Shared.Utils.TokenServices
{
    public interface ITokenService
    {
        string CreateToken(AuthUser user);
    }
}
