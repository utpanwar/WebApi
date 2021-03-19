using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Models;
using Models;

namespace Services
{
    public class CharaterService : ICharaterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Thuma"}

        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
        {
             ServiceResponse<List<Character>> serviceRes = new ServiceResponse<List<Character>>();
             characters.Add(newCharacter);
             serviceRes.Data = characters;
             return serviceRes;
            // return 
        }
        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            ServiceResponse<Character> serviceRes = new ServiceResponse<Character>();
            serviceRes.Data = characters.FirstOrDefault(c => c.Id == id);
            return serviceRes;
        }
        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            ServiceResponse<List<Character>> serviceRes = new ServiceResponse<List<Character>>();
            serviceRes.Data = characters;
            return serviceRes;
        }
    }
}