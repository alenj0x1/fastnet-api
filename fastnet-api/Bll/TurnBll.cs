using fastnet_api.DBModels;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class TurnBll
    {
        FastnetdbContext ContextDB;
        public TurnBll()
        {
            ContextDB = new FastnetdbContext();
        }

        TurnRepository TurnRep = new();

        public List<Turn> GetTurnsByCashId(int cashId)
        {
            return TurnRep.GetTurnsByCashId(ContextDB, cashId, false);
        }

        public List<Turn> GetAllTurns(int cashierId)
        {
            return TurnRep.GetAllTurns(ContextDB, cashierId, false);
        }

        public Attention? TakeTurn(int turnId, int cashierId)
        {
            return TurnRep.TakeTurn(ContextDB, turnId, cashierId);
        }

        public Turn? GetCurrentTurn(int cashierId)
        {
            return TurnRep.GetCurrentTurn(ContextDB, cashierId);
        }

        public Turn? NextTurn(int cashierId)
        {
            return TurnRep.NextTurn(ContextDB, cashierId);
        }
    }
}
