using fastnet_api.DBModels;
using fastnet_api.Models.Attention;

namespace fastnet_api.Repository
{
    public class AttentionRepository
    {
        CashRepository CashRep = new();

        public int? NewAttention(FastnetdbContext ContextDB, NewAttentionRequestModel model)
        {
            if (model.ClientId != null) {
                Attention? FindAttentionActive = ContextDB.Attentions.FirstOrDefault(x => x.ClientClientid == model.ClientId);
                Client? FindClient = ContextDB.Clients.SingleOrDefault(x => x.Clientid == model.ClientId);
                
                if (FindClient == null)
                {
                    return null;
                }

                if (FindAttentionActive != null)
                {
                    return null;
                }
            }

            Attentiontype? AttentionTypeValid = GetAttentionType(ContextDB, model.AttentionType);

            if (AttentionTypeValid == null) {
                return null;
            }

            Cash? FindCash = CashRep.GetCashById(ContextDB, model.CashId);

            if (FindCash == null) {
                return null;
            }

            Turn NewTurn = new()
            {
                CashCashid = model.CashId,
                Usergestorid = 1,
                Turnstatusid = 1, // waiting
            };
            ContextDB.Turns.Add(NewTurn);
            ContextDB.SaveChanges();

            Attention AttentionNew = new()
            {
                ClientClientid = model.ClientId,
                AttentiontypeAttentiontypeid = model.AttentionType,
                AttentionstatusStatusid = 1,// waiting
                TurnTurnid = NewTurn.Turnid,
            };

            ContextDB.Attentions.Add(AttentionNew);
            ContextDB.SaveChanges();

            return AttentionNew.Attentionid;
        }

        public Attentiontype? GetAttentionType(FastnetdbContext ContextDB, int attentionType)
        {
            return ContextDB.Attentiontypes.SingleOrDefault(x => x.Attentiontypeid == attentionType);
        }

        public List<Attention> GetAttentions(FastnetdbContext ContextDB)
        {
            return ContextDB.Attentions.ToList();
        }

        public Attention? GetAttentionById(FastnetdbContext ContextDB, int attentionId)
        {
            return ContextDB.Attentions.SingleOrDefault(x => x.Attentionid == attentionId);
        }

        public Attention? GetAttentionByClientId(FastnetdbContext ContextDB, int clientId)
        {
            return ContextDB.Attentions.SingleOrDefault(x => x.ClientClientid == clientId);
        }

        public int? CloseAttention(FastnetdbContext ContextDB, int attentionId)
        {
            Attention? FindAttention = GetAttentionById(ContextDB, attentionId);

            if (FindAttention == null)
            {
                return null;
            }

            if (FindAttention.AttentionstatusStatusid == 3)
            {
                return null;
            }

            Turn? FindTurn = ContextDB.Turns.SingleOrDefault(x => x.Turnid == FindAttention.TurnTurnid);

            FindTurn.Turnstatusid = 3; // ended
            FindAttention.AttentionstatusStatusid = 3; // ended

            ContextDB.SaveChanges();

            return 1;
        }

        public Attention? GetAttentionByTurnId(FastnetdbContext ContextDB, int turnId)
        {
            Attention? FindAttention = ContextDB.Attentions.SingleOrDefault(x => x.TurnTurnid == turnId);

            if (FindAttention == null)
            {
                return null;
            }

            return FindAttention;
        }

        public Attention? GetAttentionTakedByCashier(FastnetdbContext ContextDB, int turnId, int cashierId)
        {
            return new Attention();
        }
    }
}
