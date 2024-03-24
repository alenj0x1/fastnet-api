using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using Microsoft.EntityFrameworkCore;

namespace fastnet_api.Repository
{
    public class UserRepository
    {

        public User? GetUser(FastnetdbContext contextDB, LoginRequestModel value)
        {
            User? FindUser = contextDB.Users.SingleOrDefault(User => User.Username == value.username);

            return FindUser;
        }
    }
}
