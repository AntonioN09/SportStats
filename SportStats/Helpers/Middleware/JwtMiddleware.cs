using SportStats.Controllers.Jwt;
using SportStats.Services.ManagerService;

namespace SportStats.Helpers.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IManagerService managerService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != Guid.Empty)
            {

                httpContext.Items["Manager"] = managerService.GetById(userId);

            }

            await _next(httpContext);
        }
    }
}
