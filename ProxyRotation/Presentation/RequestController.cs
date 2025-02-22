using Microsoft.AspNetCore.Mvc;

namespace ProxyRotation.Presentation
{
    [ApiController]
    [Route("/Request")]
    public class RequestController : ControllerBase
    {
        [HttpGet]
        [Route("/alive")]
        public IActionResult Alive()
        {
            return Ok("I'm alive boss");
        }


        [HttpPost]
        [Route("/")]
        public IActionResult Rotate()
        {
            return Ok();
        }
    }
} 
