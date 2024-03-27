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
    }
}
