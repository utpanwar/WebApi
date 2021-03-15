using System.Collections.Generic;
using System.Linq;
using Controllers.Models;
using Microsoft.AspNetCore.Mvc;
namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        // private static Character Knight = new Character();
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{ Id = 1, Name = "Thuma"}

        };
        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        // [HttpPost]
        // public IActionResult GetSingle()
        // {
        //     return Ok(characters[0]);
        // }
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}