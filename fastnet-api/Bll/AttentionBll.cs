using fastnet_api.DBModels;
using fastnet_api.Models.Attention;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class AttentionBll
    {
        FastnetdbContext ContextDB;
        public AttentionBll()
        {
            ContextDB = new FastnetdbContext();
        }

        AttentionRepository AttentionRep = new();

        public int? NewAttention(NewAttentionRequestModel model)
        {
            return AttentionRep.NewAttention(ContextDB, model);
        }

        public Attentiontype? GetAttentionType(int attentionType) {
            return AttentionRep.GetAttentionType(ContextDB, attentionType);
        }

        public List<Attention> GetAttentions()
        {
            return AttentionRep.GetAttentions(ContextDB);
        }

        public Attention? GetAttentionById(int attentionId) {
            return AttentionRep.GetAttentionById(ContextDB, attentionId);
        }

        public Attention? GetAttentionByClientId(int clientId)
        {
            return AttentionRep.GetAttentionByClientId(ContextDB, clientId);
        }

        public int? CloseAttention(int attentionId)
        {
            return AttentionRep.CloseAttention(ContextDB, attentionId);
        }
    }
}
