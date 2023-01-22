namespace JwtWebApi.Models
{
    public class Tip
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User? User { get; set; }
    }
}
