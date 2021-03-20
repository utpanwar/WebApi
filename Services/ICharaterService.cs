using System.Collections.Generic;
using System.Threading.Tasks;
using Controllers.Models;
using Dtos.Character;
using Models;

namespace Services
{
    public interface ICharaterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto newCharacter);
         Task<ServiceResponse<List<GetCharacterDto>>> Delete(int id);
         
    }
}