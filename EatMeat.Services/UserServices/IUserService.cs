using EatMeat.Database.Entities;
using EatMeat.Services.UserServices.Models;

namespace EatMeat.Services.UserServices
{
    public interface IUserService
    {
        void Create(UserEntity userEntity);
        void Update(UserEntity userEntity);
        void Delete(UserEntity userEntity);
        Task<UserEntity> GetByIdAsync(long id);
        Task<UserEntity> GetByEmailAndLoginAsync(string email, string login);
        Task<UserEntity> GetByLoginAndPassword(string login, string password);
        Task<bool> SignUp(SignUpViewModel vm);
        Task<bool> SignIn(SignInViewModel vm);
        void SignOut();
    }
}