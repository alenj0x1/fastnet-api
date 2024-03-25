using fastnet_api.DBModels;

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

        public Cash? AssignCash(FastnetdbContext contextDB, int cashId, int userId)
        {
            List<Cash> FindCashes = contextDB.Cashes.ToList();

            // Without cashes
            if (FindCashes.Count == 0)
            {
                return null;
            }

            Cash? FindCash = FindCashes.SingleOrDefault(x => x.Cashid == cashId);

            // Invalid cash
            if (FindCash == null)
            {
                return null;
            }

            Usercash? FindUserCash = contextDB.Usercashes.SingleOrDefault(x => x.UserUserid == userId);

            // Update user cash
            if (FindUserCash != null) {
                FindUserCash.CashCashid = cashId;

                contextDB.SaveChanges();

                return FindCash;
            }

            // create and add new usercash
            var newUserCash = contextDB.Usercashes.Add(new Usercash {
                UserUserid = userId,
                CashCashid = cashId
            });

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
