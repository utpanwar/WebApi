using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Models;

namespace Services
{
    public class CharaterService : ICharaterService
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Thuma"}

        };
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
             characters.Add(newCharacter);
             return characters;
            // return 
        }
        public async Task<Character> GetCharacterById(int id)
        {
            return characters.FirstOrDefault(c => c.Id == id);
        }
        public async Task<List<Character>> GetAllCharacters()
        {
            return characters;
        }
    }
}