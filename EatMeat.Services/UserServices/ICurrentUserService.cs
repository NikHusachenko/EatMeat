using EatMeat.Database.Enums;

namespace EatMeat.Services.UserServices
{
    public interface ICurrentUserService
    {
        long? Id { get; }
        string? Email { get; }
        string? Login { get; }
        UserTypes? Role { get; }
        bool? IsAuthenticated { get; }
        bool? IsAdmin { get; }
    }
}