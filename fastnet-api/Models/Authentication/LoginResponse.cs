namespace fastnet_api.Models.Authentication
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public bool Result { get; set; }
        public string Msg { get; set; }
    }
}
