using fastnet_api.DBModels;
using fastnet_api.Models.Contract;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class ContractBll
    {
        FastnetdbContext ContextDB;
        public ContractBll()
        {
            ContextDB = new FastnetdbContext();
        }

        ContractRepository ContractRep = new();

        public Contract? NewContract(NewContractRequestModel model)
        {
            return ContractRep.NewContract(ContextDB, model);
        }

        public Contract? GetContractById(int contractId)
        {
            return ContractRep.GetContractById(ContextDB, contractId);
        }

        public Contract? GetContractByClientId(int clientId)
        {
            return ContractRep.GetContractByClientId(ContextDB, clientId);
        }

        public Contract? UpdateContract(UpdateContractRequestModel model)
        {
            return ContractRep.UpdateContract(ContextDB, model);
        }

        public Contract? EndContract(int clientId)
        {
            return ContractRep.EndContract(ContextDB, clientId);
        }
    }
}
