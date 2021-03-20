using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Models;
using Dtos.Character;
using Models;

namespace Services
{
    public class CharaterService : ICharaterService
    {
        private static List<GetCharacterDto> characters = new List<GetCharacterDto>
        {
            new Character(),
            new Character{ Id = 1, Name = "Thuma"}

        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(Character newCharacter)
        {
             ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
             characters.Add(newCharacter);
             serviceRes.Data = characters;
             return serviceRes;
            // return 
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceRes = new ServiceResponse<GetCharacterDto>();
            serviceRes.Data = characters.FirstOrDefault(c => c.Id == id);
            return serviceRes;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            serviceRes.Data = characters;
            return serviceRes;
        }
    }
}