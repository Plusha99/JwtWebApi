using System.Text.Json.Serialization;

namespace JwtWebApi.Models
{
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public string Username { get; set; } = string.Empty;
        [JsonIgnore]
        public byte[] PasswordHash { get; set; }
        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public List<Tip> Tips { get; set; }
    }
}
