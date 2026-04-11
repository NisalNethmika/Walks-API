using Microsoft.AspNetCore.Identity;

namespace WebApp1.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<String> roles);
    }
}
