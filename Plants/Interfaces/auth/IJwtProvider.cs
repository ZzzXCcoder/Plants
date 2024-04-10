using WebApplication1.Models;

namespace Plants.Interfaces.auth
{
    public interface IJwtProvider
    {
        string GenerateToken(Account account);
    }
}
