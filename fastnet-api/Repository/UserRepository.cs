using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using fastnet_api.Models.Users;
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

        public List<User> GetUsers(FastnetdbContext contextDB)
        {
            List<User> users = contextDB.Users.ToList();

            return users;
        }

        public User? GetUserById(FastnetdbContext contextDB, int userId) {
            User? FindUser = contextDB.Users.SingleOrDefault(User => User.Userid == userId);

            return FindUser;
        }
        public User? GetUserByUsername(FastnetdbContext contextDB, string username)
        {
            User? FindUser = contextDB.Users.SingleOrDefault(User => User.Username == username);

            return FindUser;
        }


        public User UpdateUser(FastnetdbContext contextDB, User user)
        {
            contextDB.Users.Update(user);
            contextDB.SaveChanges();

            return user;
        }

        public User CreateUser(FastnetdbContext contextDB, User user) {
            contextDB.Users.Add(user);
            contextDB.SaveChanges();

            return user;
        }

        public User RemoveUser(FastnetdbContext contextDB, User user)
        {
            contextDB.Users.Remove(user);
            contextDB.SaveChanges();

            return user;
        }
    }
}
