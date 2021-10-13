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
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> res = new ServiceResponse<string>();
            User user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            if(null == user)
            {
                res.message = "Usename does not exits!";
                res.Success = false;
                return res;
            }
            else if(!VerifyLoginpassword(password, user.PasswordHash , user.PasswordSalt))
            {
                    res.message = "wrong password";
                    res.Success = false;
            }
            else
            {
                res.Data = user.Username;
                res.message = "Login Successfully";
                res.Success = true;
            }
            return res;
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

        private bool VerifyLoginpassword(string password, byte[] passHash, byte[] passSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i =0; i<passHash.Length; i++)
                {
                    if(computedHash[i]!=passHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}