using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controllers.Models;
using Dtos.Character;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(await _character.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
             return Ok(await _character.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
        //    characters.Add(newCharacter);
            return Ok(await _character.AddCharacter(newCharacter));
        }
    }
}