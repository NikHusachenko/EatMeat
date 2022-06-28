using EatMeat.Database.Entities;
using EatMeat.EntityFramework.Repository;
using EatMeat.Services.AuthenticationServices;
using EatMeat.Services.UserServices.Models;
using Microsoft.EntityFrameworkCore;

namespace EatMeat.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<UserEntity> _genericRepository;
        private readonly IAuthenticationService _authenticationService;

        public UserService(IGenericRepository<UserEntity> genericRepository,
            IAuthenticationService authenticationService)
        {
            _genericRepository = genericRepository;
            _authenticationService = authenticationService;
        }

        public void Create(UserEntity userEntity)
        {
            _genericRepository.Create(userEntity);
        }

        public void Delete(UserEntity userEntity)
        {
            userEntity.Deleted = DateTime.Now;
            Update(userEntity);
        }

        public async Task<UserEntity> GetByIdAsync(long id)
        {
            return await _genericRepository.Table
                .Include(user => user.Meats)
                .FirstOrDefaultAsync(user => user.Id == id);
        }

        public void Update(UserEntity userEntity)
        {
            _genericRepository.Update(userEntity);
        }

        public async Task<UserEntity> GetByEmailAndLoginAsync(string email, string login)
        {
            return await _genericRepository.Table
                .FirstOrDefaultAsync(user => user.Email == email && user.Login == login);
        }

        public async Task<UserEntity> GetByLoginAndPassword(string login, string password)
        {
            return await _genericRepository.Table
                .FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
        }

        public async Task<bool> SignUp(SignUpViewModel vm)
        {
            UserEntity userEntity = await GetByEmailAndLoginAsync(vm.Email, vm.Login);
            if(userEntity != null)
            {
                return false;
            }

            UserEntity dbRecord = new UserEntity()
            {
                Created = DateTime.Now,
                Email = vm.Email,
                Login = vm.Login,
                Password = vm.Password,
                Type = Database.Enums.UserTypes.Client,
            };

            Create(dbRecord);
            _authenticationService.SignIn(dbRecord);
            return true;
        }

        public void SignOut()
        {
            _authenticationService.SignOut();
        }

        public async Task<bool> SignIn(SignInViewModel vm)
        {
            UserEntity userEntity = await GetByLoginAndPassword(vm.Login, vm.Password);
            if(userEntity == null)
            {
                return false;
            }

            _authenticationService.SignIn(userEntity);
            return true;
        }
    }
}