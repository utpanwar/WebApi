using Microsoft.AspNetCore.Mvc;
using WebApiWithPartGod.Models;
namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character Knight = new Character();

        public IActionResult GetAction()
        {
            return Ok(Knight);
        }
    }
}