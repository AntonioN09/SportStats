using SportStats.Models;

namespace SportStats.Controllers.Jwt
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Manager manager);
        public Guid ValidateJwtToken(string token);
    }
}
