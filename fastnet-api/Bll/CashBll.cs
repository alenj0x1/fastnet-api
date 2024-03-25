using fastnet_api.DBModels;
using fastnet_api.Models.Cash;
using fastnet_api.Models.Users;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class CashBll
    {
        FastnetdbContext ContextDB;
        public CashBll()
        {
            ContextDB = new FastnetdbContext();
        }

        CashRepository CashRep = new();

        public Cash CreateCash(CreateCashRequestModel model)
        {
            Cash newCash = new()
            {
               Cashdescription = model.Description,
            };
            return CashRep.CreateCash(ContextDB, newCash);
        }

        public Boolean RemoveCash(int cashId)
        {
            Cash? FindCash = ContextDB.Cashes.SingleOrDefault(x => x.Cashid == cashId);

            if (FindCash == null) {
                return false;
            }

            CashRep.RemoveCash(ContextDB, FindCash);
            return true;
        }

        public Cash? GetCashById(int cashId)
        {
            return CashRep.GetCashById(ContextDB, cashId);
        }

        public Cash? GetCashByCashierId(int cashierId)
        {
            return CashRep.GetCashByCashierId(ContextDB, cashierId);
        }

        public List<Cash> GetCashes()
        {
            return CashRep.GetCashes(ContextDB);
        }

        public Cash? AssignCash(AssignCashRequestModel model)
        {
            return CashRep.AssignCash(ContextDB, model.cashId, model.userId);
        }

        public Usercash? RemoveAssignedCash(int userId) { 
            return CashRep.RemoveAssignedCash(ContextDB, userId);
        }
    }
}
