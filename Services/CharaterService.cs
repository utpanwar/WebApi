using System;
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
        // public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        // {
        //     ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
        //     characters.Add(_mapper.Map<Character>(newCharacter));
        //     serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(characters);
        //     return serviceRes;
        // }
        // now generation by ourself
         public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.Id = characters.Max(c => c.Id) + 1;
            characters.Add(character);
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
            // serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            // this is also ways of doing the same above
            serviceRes.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceRes;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceRes = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = characters.FirstOrDefault(c => updateCharacter.Id == c.Id);
                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defencse = updateCharacter.Defencse;
                character.HitPoints = updateCharacter.HitPoints;
                // characters.Add(character);
                serviceRes.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                serviceRes.message = ex.Message;
                serviceRes.Success =false;  
            }
            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            try {
                Character character = characters.Find(c => c.Id == id);
                characters.Remove(character);
                serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(characters);
            }
            catch(Exception ex)
            {
                // serviceRes.Data = null;
                serviceRes.message = ex.Message;
                serviceRes.Success = false;
            }
            return serviceRes;
        }
    }
}