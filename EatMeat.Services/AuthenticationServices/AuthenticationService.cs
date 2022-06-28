using EatMeat.Common;
using EatMeat.Database.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace EatMeat.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SignIn(UserEntity userEntity)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(Claims.ID, userEntity.Id.ToString()),
                new Claim(Claims.EMAIL, userEntity.Email),
                new Claim(Claims.LOGIN, userEntity.Login),
                new Claim(Claims.ROLE, userEntity.Type.ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            _httpContextAccessor.HttpContext.SignInAsync(claimsPrincipal);
        }

        public void SignOut()
        {
            _httpContextAccessor.HttpContext.SignOutAsync();
        }
    }
}