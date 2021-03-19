using System.Collections.Generic;
using System.Threading.Tasks;
using Controllers.Models;
using Models;

namespace Services
{
    public interface ICharaterService
    {
         Task<ServiceResponse<List<Character>>> GetAllCharacters();
         Task<ServiceResponse<Character>> GetCharacterById(int id);
         Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);

    }
}