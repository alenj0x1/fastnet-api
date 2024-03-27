using fastnet_api.DBModels;
using fastnet_api.Models.Users;
using fastnet_api.Repository;
using fastnet_api.Services;

namespace fastnet_api.Bll
{
    public class UserBll
    {
        FastnetdbContext ContextDB;
        public UserBll()
        {
            ContextDB = new FastnetdbContext();
        }

        UserRepository UserRep = new();

        public List<User> GetUsers()
        {
            return UserRep.GetUsers(ContextDB);
        }

        public User? GetUser(int userId)
        {
            return UserRep.GetUserById(ContextDB, userId);
        }

        public User? GetUserByUsername(string username)
        {
            return UserRep.GetUserByUsername(ContextDB, username);
        }

        public User UpdateUser(User user)
        {
            return UserRep.UpdateUser(ContextDB, user);
        }

        public User CreateUser(User user)
        {
            return UserRep.CreateUser(ContextDB, user);
        }

        public User RemoveUser(User user)
        {
            return UserRep.RemoveUser(ContextDB, user);
        }
    }
}
