using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Models;
using Dtos.Character;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        // private static Character Knight = new Character();
        private readonly ICharaterService  _character ;
        public CharacterController(ICharaterService character)
        {
            _character = character;
        }
        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<GetCharacterDto>> res = await _character.GetAllCharacters();
            if(null == res.Data) return NotFound(res);
            return Ok(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<GetCharacterDto> res = await _character.GetCharacterById(id);
            if(null == res.Data) return NotFound(res);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
        //    characters.Add(newCharacter);
            return Ok(await _character.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updateCharacter)
        {
        //    characters.Add(newCharacter);
            ServiceResponse<GetCharacterDto> res = await _character.UpdateCharacter(updateCharacter);
            if(null == res.Data) return NotFound(res);
            return Ok(res);
        }

        
        [Route("Delete")] // this will not works becausse we are having params in httdelete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
        //    characters.Add(newCharacter);
            ServiceResponse<List<GetCharacterDto>> res = await _character.Delete(id);
            if(null == res.Data) return NotFound(res);
            return Ok(res);
        }
    }
}