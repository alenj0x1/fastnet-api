using fastnet_api.DBModels;

namespace fastnet_api.Repository
{
    public class UsercashRepository
    {
        public Usercash? GetUsercashById(FastnetdbContext ContextDB, int cashierId)
        {
            return ContextDB.Usercashes.SingleOrDefault(x => x.UserUserid == cashierId);
        }
    }
}
