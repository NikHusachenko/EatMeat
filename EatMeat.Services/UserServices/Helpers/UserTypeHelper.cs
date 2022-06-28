using EatMeat.Database.Enums;

namespace EatMeat.Services.UserServices.Helpers
{
    public class UserTypeHelper
    {
        public static UserTypes? GetUserTypeAsEnum(string type)
        {
            switch(type.ToLower())
            {
                case "admin":
                    {
                        return UserTypes.Admin;
                    }
                case "client":
                    {
                        return UserTypes.Client;
                    }
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
