using fastnet_api.DBModels;
using fastnet_api.Models.Contract;

namespace fastnet_api.Repository
{
    public class ContractRepository
    {
        public Contract NewContract(FastnetdbContext ContextDB, NewContractRequestModel model)
        {
            return new Contract();
        }
    }
}
