using System.Collections.Generic;
using System.Threading.Tasks;
using Controllers.Models;

namespace Services
{
    public interface ICharaterService
    {
         Task<List<Character>> GetAllCharacters();
         Task<Character> GetCharacterById(int id);
         Task<List<Character>> AddCharacter(Character newCharacter);

    }
}