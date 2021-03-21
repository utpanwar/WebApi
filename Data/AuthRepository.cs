using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<ServiceResponse<int>> Login(string user, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> res = new ServiceResponse<int>();
            if(await UserExits(user.Username))
            {
                res.message = "user alredy exits";
                res.Success = false;
                return res;
            }
            
            CreatePasswordHash(password, out byte[] passHash, out byte[] passSalt);
            user.PasswordHash = passHash;
            user.PasswordSalt = passSalt;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            res.Data = user.Id;
            return res;
        }

        public async Task<bool> UserExits(string username)
        {
            if(await _context.Users.AnyAsync(x => x.Username.ToLower() == username.ToLower()))
            {
                return true;
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passHash , out byte[] passSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
        }
    }
}