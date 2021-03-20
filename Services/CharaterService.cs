using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Controllers.Models;
using Dtos.Character;
using Models;

namespace Services
{
    public class CharaterService : ICharaterService
    {
        private readonly IMapper _mapper;
        public CharaterService(IMapper mapper)
        {
            _mapper = mapper;

        }
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Thuma"}

        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            characters.Add(_mapper.Map<Character>(newCharacter));
            serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return serviceRes;
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceRes = new ServiceResponse<GetCharacterDto>();
            serviceRes.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
            return serviceRes;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            return serviceRes;
        }
    }
}