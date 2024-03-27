using fastnet_api.DBModels;
using fastnet_api.Models.Clients;

namespace fastnet_api.Repository
{
    public class ClientsRepository
    {
        public List<Client>? GetClients(FastnetdbContext ContextDB)
        {
            List<Client>? FindClients = ContextDB.Clients.ToList();

            return FindClients;
        }

        public Client? GetClientByIdentification(FastnetdbContext ContextDB, string clientIdentification) {
            Client? FindClient = ContextDB.Clients.SingleOrDefault(x => x.Identification == clientIdentification);

            if (FindClient == null)
            {
                return null;
            }

            return FindClient;
        }

        public Client? NewClient(FastnetdbContext ContextDB, NewClientRequestModel model) {
            Client? CheckClientIdentification = GetClientByIdentification(ContextDB, model.Identification);

            if (CheckClientIdentification != null) {
                return null;
            }

            Client ClientNew = new Client()
            {
                Name = model.Name,
                Lastname = model.LastName,
                Identification = model.Identification,
                Email = model.Email,
                Phonenumber = model.PhoneNumber,
                Address = model.Address,
                Referenceaddress = model.ReferenceAddress
            };

            ContextDB.Add(ClientNew);
            ContextDB.SaveChanges();

            return ClientNew;
        }

        public Client? GetClientById(FastnetdbContext ContextDB, int clientId)
        {
            Client? FindClient = ContextDB.Clients.SingleOrDefault(x => x.Clientid == clientId);

            if (FindClient == null)
            {
                return null;
            }

            return FindClient;
        }

        public Client? UpdateClient(FastnetdbContext ContextDB, int clientId, UpdateClientRequestModel model)
        {
            Client? FindClient = GetClientById(ContextDB, clientId);

            if (FindClient == null)
            {
                return null;
            }

            FindClient.Name = model.Name != null ? model.Name : FindClient.Name;
            FindClient.Lastname = model.LastName != null ? model.LastName : FindClient.Lastname;
            FindClient.Identification = model.Identification != null ? model.Identification : FindClient.Identification;
            FindClient.Email = model.Email != null ? model.Email : FindClient.Email;
            FindClient.Phonenumber = model.PhoneNumber != null ? model.PhoneNumber : FindClient.Phonenumber;
            FindClient.Address = model.Address != null ? model.Address : FindClient.Address;
            FindClient.Referenceaddress = model.ReferenceAddress != null ? model.ReferenceAddress : FindClient.Referenceaddress;

            ContextDB.SaveChanges();

            return FindClient;
        }

        public Client? RemoveClient(FastnetdbContext ContextDB, int clientId)
        {
            Client? FindClient = GetClientById(ContextDB, clientId);

            if (FindClient == null)
            {
                return null;
            }

            ContextDB.Remove(FindClient);

            return FindClient;
        }
    }
}
