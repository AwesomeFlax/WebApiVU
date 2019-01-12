namespace WebApiVU.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Status { get; set; }
        public string Group { get; set; }
        public bool Active { get; set; }
    }
}
