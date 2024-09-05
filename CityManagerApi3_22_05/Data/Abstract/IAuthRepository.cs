using CityManagerApi3_22_05.Entities;

namespace CityManagerApi3_22_05.Data.Abstract
{
    public interface IAuthRepository
    {
        Task<User> Register(User user,string password);
        Task<User> Login(string username,string password);
        Task<bool> UserExists(string username);
    }
}
