namespace Web_API.Auth
{
    public class AuthPayload
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool Verified { get; set; } = false;
    }
}