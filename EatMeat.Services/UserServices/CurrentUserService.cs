using EatMeat.Common;
using EatMeat.Database.Enums;
using EatMeat.Services.UserServices.Helpers;
using Microsoft.AspNetCore.Http;

namespace EatMeat.Services.UserServices
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor = contextAccessor;
        }

        public long? Id
        {
            get
            {
                try
                {
                    if (_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(user => user.Type == Claims.ID)?.Value == null)
                    {
                        return null;
                    }
                    else
                    {
                        return long.Parse(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(user => user.Type == Claims.ID)?.Value);
                    }
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }

        public string? Email
        {
            get
            {
                try
                {
                    return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(user => user.Type == Claims.EMAIL).Value;
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }

        public string? Login
        {
            get
            {
                try
                {
                    return _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == Claims.LOGIN)?.Value;
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }

        public UserTypes? Role
        {
            get
            {
                try
                {
                    if(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == Claims.ROLE) == null)
                    {
                        return null;
                    }
                    else
                    {
                        return UserTypeHelper.GetUserTypeAsEnum(_httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == Claims.ROLE)?.Value);
                    }
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }

        public bool? IsAuthenticated
        {
            get
            {
                try
                {
                    return _httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated;
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }

        public bool? IsAdmin
        {
            get
            {
                try
                {
                    if(Role == null)
                    {
                        return null;
                    }
                    else
                    {
                        return Role == UserTypes.Admin;
                    }
                }
                catch (NullReferenceException ex)
                {
                    return null;
                }
            }
        }
    }
}