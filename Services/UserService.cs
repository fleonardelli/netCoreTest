using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using api.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace api.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UserClaims getAuthenticatedUserClaims()
        {
            var identity = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim  = identity.Claims.ToList();

            UserClaims userClaims = new UserClaims();
            userClaims.Issuer = claim[0].Issuer;
            userClaims.Email = claim[0].Value;

            return userClaims;
        }
    }
}