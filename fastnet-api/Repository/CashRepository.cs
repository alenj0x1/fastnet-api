using fastnet_api.DBModels;
using fastnet_api.Models.Users;

namespace fastnet_api.Repository
{
    public class CashRepository
    {
        public List<Cash> GetCashes(FastnetdbContext contextDB)
        {
            return contextDB.Cashes.ToList();
        }

        public Cash? GetCashById(FastnetdbContext contextDB, int cashId)
        {
            return contextDB.Cashes.SingleOrDefault(x => x.Cashid == cashId);
        }

        public Cash? GetCashByCashierId(FastnetdbContext contextDB, int cashierId)
        {
            Usercash? CashierCash = contextDB.Usercashes.SingleOrDefault(x => x.UserUserid == cashierId);

            if (CashierCash == null)
            {
                return null;
            }

            return GetCashById(contextDB, CashierCash.CashCashid);
        }

        public Cash CreateCash(FastnetdbContext contextDB, Cash newCash)
        {
            contextDB.Add(newCash);

            contextDB.SaveChanges();

            return newCash;
        }

        public Cash RemoveCash(FastnetdbContext contextDB, Cash cash) {
            contextDB.Remove(cash);
            contextDB.SaveChanges();

            return cash;
        }

        public Cash? AssignCash(FastnetdbContext contextDB, AssignCashRequestModel model)
        {
            List<Cash> FindCashes = GetCashes(contextDB);

            // Without cashes
            if (FindCashes.Count == 0)
            {
                return null;
            }

            Cash? FindCash = GetCashById(contextDB, model.cashId);

            // Invalid cash
            if (FindCash == null)
            {
                return null;
            }

            // Update status of cash
            if (FindCash.Active == false)
            {
                FindCash.Active = true;
            }

            Usercash? FindUserCash = contextDB.Usercashes.SingleOrDefault(x => x.UserUserid == model.userId);
            List<Usercash> FindCashesUsers = contextDB.Usercashes.Where(x => x.CashCashid == model.cashId).ToList();

            // Cash max 3 users
            if (FindCashesUsers.Count == 3)
            {
                return null;
            }

            // Update user cash
            if (FindUserCash != null) {
                contextDB.Usercashes.Remove(FindUserCash);
            }

            // create and add new usercash
            Usercash newUserCash = new()
            {
                UserUserid = model.userId,
                CashCashid = model.cashId,
            };

            contextDB.Usercashes.Add(newUserCash);
            contextDB.SaveChanges();

            return FindCash;
        }

        public Usercash? RemoveAssignedCash(FastnetdbContext contextDB, int userId)
        {
            Usercash? FindUserCash = contextDB.Usercashes.SingleOrDefault(x => x.UserUserid == userId);

            if (FindUserCash == null) {
                return null;
            }

            contextDB.Usercashes.Remove(FindUserCash);
            contextDB.SaveChanges();

            return FindUserCash;
        }
    }
}
