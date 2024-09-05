namespace CityManagerApi3_22_05.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public byte[]?PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
