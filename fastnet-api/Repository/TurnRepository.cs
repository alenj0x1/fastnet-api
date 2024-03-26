using fastnet_api.DBModels;

namespace fastnet_api.Repository
{
    public class TurnRepository
    {
        UsercashRepository UserCashRep = new();
        AttentionRepository AttentioRep = new();

        public List<Turn> GetTurnsByCashId(FastnetdbContext ContextDB, int cashId, bool takedTurn)
        {
            if (takedTurn)
            {
                return ContextDB.Turns.Where(x => x.CashCashid == cashId && x.Turnstatusid == 2).ToList();
            }
            
            return ContextDB.Turns.Where(x => x.CashCashid == cashId && x.Turnstatusid == 1).ToList();
        }

        public List<Turn> GetAllTurns(FastnetdbContext ContextDB, int cashierId, bool takedTurn)
        {
            Usercash? FindUsercash = UserCashRep.GetUsercashById(ContextDB, cashierId);

            if (FindUsercash == null)
            {
                return null;
            }

            return GetTurnsByCashId(ContextDB, FindUsercash.CashCashid, takedTurn);
        }

        public Attention? TakeTurn(FastnetdbContext ContextDB, int turnId, int cashierId)
        {
            Turn? FindTurnTakedByCashier = GetCurrentTurn(ContextDB, cashierId);

            if (FindTurnTakedByCashier != null)
            {
                return null;
            }

            Usercash? FindCashierCash = UserCashRep.GetUsercashById(ContextDB, cashierId);
            Turn? FindTurn = ContextDB.Turns.SingleOrDefault(x => x.Turnid == turnId && x.Turnstatusid == 1 && x.CashCashid == FindCashierCash.CashCashid);

            if (FindTurn  == null)
            {
                return null;
            }

            Attention? FindAttention = AttentioRep.GetAttentionByTurnId(ContextDB, turnId);

            FindAttention.AttentionstatusStatusid = 2; // taked
            FindTurn.Turnstatusid = 2; // taked

            ContextDB.SaveChanges();

            return FindAttention;
        }

        public Turn? GetCurrentTurn(FastnetdbContext ContextDB, int cashierId)
        {
            List<Turn> FindTurns = GetAllTurns(ContextDB, cashierId, true).ToList();

            Turn? FindTurnTaked = FindTurns.SingleOrDefault(x => x.Turnstatusid == 2);

            if (FindTurnTaked == null)
            {
                return null;
            }

            return FindTurnTaked;
        }

        public Turn? NextTurn(FastnetdbContext ContextDB, int cashierId)
        {
            List<Turn> FindTurns = GetAllTurns(ContextDB, cashierId, true);

            Turn? FindTurnTaked = FindTurns.SingleOrDefault(x => x.Turnstatusid == 2);

            if (FindTurnTaked == null)
            {
                return null;
            }

            FindTurnTaked.Turnstatusid = 3;

            ContextDB.SaveChanges();

            return FindTurnTaked;
        }
    }
}
