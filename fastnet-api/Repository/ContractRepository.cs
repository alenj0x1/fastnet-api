using fastnet_api.DBModels;
using fastnet_api.Models.Contract;

namespace fastnet_api.Repository
{
    public class ContractRepository
    {
        public Contract? NewContract(FastnetdbContext ContextDB, NewContractRequestModel model)
        {
            Contract? CheckContractClient = ContextDB.Contracts.SingleOrDefault(x => x.ClientClientid == model.ClientId && x.StatuscontractStatusid == 1);
            Service? CheckService = ContextDB.Services.SingleOrDefault(x => x.Serviceid == model.ServiceId);

            if (CheckContractClient != null) 
            {
                return null;
            }

            if (CheckService == null)
            {
                return null;
            }

            Contract ContractNew = new()
            {
                ServiceServiceid = model.ServiceId,
                ClientClientid = model.ClientId,
                StatuscontractStatusid = 1, //active
                MethodpaymentMethodpaymentid = 1 // cash
            };

            ContextDB.Contracts.Add(ContractNew);

            Payment PaymentService = new()
            {
                Clientid = model.ClientId,
                Description = "first service payment",
                Amount = Double.Parse(CheckService.Price)
            };

            ContextDB.Payments.Add(PaymentService);
            ContextDB.SaveChanges();

            return ContractNew;
        }

        public Contract? GetContractById(FastnetdbContext ContextDB, int contractId)
        {
            Contract? FindContract = ContextDB.Contracts.SingleOrDefault(x => x.Contracid == contractId);

            if (FindContract == null)
            {
                return null;
            }

            return FindContract;
        }

        public Contract? GetContractByClientId(FastnetdbContext ContextDB, int clientId)
        {
            Contract? FindContract = ContextDB.Contracts.SingleOrDefault(x => x.ClientClientid == clientId);

            if (FindContract == null)
            {
                return null;
            }

            return FindContract;
        }

        public Contract? UpdateContract(FastnetdbContext ContextDB, UpdateContractRequestModel model)
        {
            Contract? FindContract = GetContractByClientId(ContextDB, model.ClientId);

            if (FindContract == null)
            {
                return null;
            }

            FindContract.ServiceServiceid = model.ServiceId;
            ContextDB.SaveChanges();

            return FindContract;
        }

        public Contract? EndContract(FastnetdbContext ContextDB, int clientId)
        {
            Contract? FindContract = GetContractByClientId(ContextDB, clientId);

            if (FindContract == null)
            {
                return null;
            }

            ContextDB.Remove(FindContract);
            ContextDB.SaveChanges();

            return FindContract;
        }
    }
}
