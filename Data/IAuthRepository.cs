using System.Threading.Tasks;
using Models;

namespace Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string user, string password);
        Task<bool> UserExits(string username);
    }
}