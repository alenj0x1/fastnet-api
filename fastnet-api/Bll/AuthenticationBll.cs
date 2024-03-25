using fastnet_api.DBModels;
using fastnet_api.Models.Authentication;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class AuthenticationBll
    {
        FastnetdbContext ContextDB;
        public AuthenticationBll()
        {
            ContextDB = new FastnetdbContext();
        }

        UserRepository UserRep = new();

        public User? LoginUser(LoginRequestModel value)
        {
           User? FindUser = UserRep.GetUser(ContextDB, value);

           if (FindUser == null)
            {
                return null;
            }

            Boolean CheckPassword = FindUser.Password == value.password;

            if (!CheckPassword)
            {
                return null;
            }

            return FindUser;
        }
    }
}
