using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Web.Services
{
    public class CurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user == null)
            {
                throw new InvalidOperationException("This request does not have an authenticated user.");
            }

            UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);


        }

        public string UserId { get; }
    }
}
