using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Controllers.Models;
using Data;
using Dtos.Character;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services
{
    public class CharaterService : ICharaterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public CharaterService(IMapper mapper, DataContext context)
        {
            _context = context;
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
            // character.Id = characters.Max(c => c.Id) + 1;
            // characters.Add(character); // it is list in its class now save in SqlServer
             await _context.Character.AddAsync(character);
             await _context.SaveChangesAsync();
            serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(await _context.Character.ToListAsync());
            return serviceRes;
        }
        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceRes = new ServiceResponse<GetCharacterDto>();
            Character DbCharacter = await _context.Character.FirstOrDefaultAsync(c => c.Id == id);
            serviceRes.Data = _mapper.Map<GetCharacterDto>(DbCharacter);
            return serviceRes;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _context.Character.ToListAsync();
            serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(dbCharacters);
            // this is also ways of doing the same above
            // serviceRes.Data = (characters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceRes;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceRes = new ServiceResponse<GetCharacterDto>();
            try
            {
                Character character = await _context.Character.FirstOrDefaultAsync(c => updateCharacter.Id == c.Id);
                character.Name = updateCharacter.Name;
                character.Class = updateCharacter.Class;
                character.Defencse = updateCharacter.Defencse;
                character.HitPoints = updateCharacter.HitPoints;
                // characters.Add(character);
                _context.Character.Update(character);
                await _context.SaveChangesAsync();
                serviceRes.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                serviceRes.message = ex.Message;
                serviceRes.Success = false;
            }
            return serviceRes;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceRes = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                Character character = await _context.Character.FirstAsync(c => c.Id == id);
                _context.Character.Remove(character);
                await _context.SaveChangesAsync();
                serviceRes.Data = _mapper.Map<List<GetCharacterDto>>(await _context.Character.ToListAsync());
            }
            catch (Exception ex)
            {
                // serviceRes.Data = null;
                serviceRes.message = ex.Message;
                serviceRes.Success = false;
            }
            return serviceRes;
        }
    }
}