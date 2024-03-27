namespace fastnet_api.Models.Clients
{
    public class UpdateClientRequestModel
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Identification { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? ReferenceAddress { get; set; }
    }
}
