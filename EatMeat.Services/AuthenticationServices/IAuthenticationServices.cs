using EatMeat.Database.Entities;

namespace EatMeat.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        void SignIn(UserEntity userEntity);
        void SignOut();
    }
}