using Microsoft.AspNetCore.Mvc;
using ProxyRotation.Application.Interface;

namespace ProxyRotation.Presentation
{
    [ApiController]
    [Route("/Request")]
    public class RequestController(IProxyRotationService _proxyRotationService) : ControllerBase
    {
        [HttpGet]
        [Route("/alive")]
        public IActionResult Alive()
        {
            return Ok("I'm alive boss");
        }


        [HttpPost]
        [Route("/")]
        public IActionResult DoRotation()
        {
            _proxyRotationService.Rotate();
            return Ok();
        }
    }
} 
