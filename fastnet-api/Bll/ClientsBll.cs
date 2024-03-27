using fastnet_api.DBModels;
using fastnet_api.Models.Clients;
using fastnet_api.Repository;

namespace fastnet_api.Bll
{
    public class ClientsBll
    {
        FastnetdbContext ContextDB;
        public ClientsBll()
        {
            ContextDB = new FastnetdbContext();
        }

        ClientsRepository ClientsRep = new();

        public List<Client>? GetClients()
        {
            return ClientsRep.GetClients(ContextDB);
        }

        public Client? NewClient(NewClientRequestModel model)
        {
            return ClientsRep.NewClient(ContextDB, model);
        }

        public Client? GetClientById(int clientId)
        {
            return ClientsRep.GetClientById(ContextDB, clientId);
        }

        public Client? GetClientByIdentification(string clientIdentification)
        {
            return ClientsRep.GetClientByIdentification(ContextDB, clientIdentification);
        }

        public Client? UpdateClient(int clientId, UpdateClientRequestModel model)
        {
            return ClientsRep.UpdateClient(ContextDB, clientId, model);
        }

        public Client? RemoveClient(int clientId)
        {
            return ClientsRep.RemoveClient(ContextDB, clientId);
        }
    }
}
