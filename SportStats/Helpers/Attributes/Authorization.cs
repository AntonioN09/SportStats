using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SportStats.Models.Enums;
using SportStats.Models;

namespace SportStats.Helpers.Attributes
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var unauthorizedStatusObject = new JsonResult(new { Message = "Unauthorized" })
            { StatusCode = StatusCodes.Status401Unauthorized };

            if (_roles == null)
            {
                context.Result = unauthorizedStatusObject;
            }

            Manager? manager = context.HttpContext.Items["Manager"] as Manager;

            if (manager == null || !_roles.Contains(manager.Role))
            {
                context.Result = unauthorizedStatusObject;
            }
        }
    }
}
