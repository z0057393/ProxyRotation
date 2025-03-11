using Microsoft.AspNetCore.Mvc;
using ProxyRotation.Presentation.Dto;
using ProxyRotation.Application.Interface;

namespace ProxyRotation.Presentation
{
    [ApiController]
    public class RequestController(IProxyRotationService _proxyRotationService) : ControllerBase
    {
        [HttpGet]
        [Route("/alive")]
        public IActionResult Alive()
        {
            return Ok("I'm alive boss");
        }
        
        [HttpPost]
        [Route("/Rotate")]
        public IActionResult DoRotation([FromBody] RequestDto req)
        {
            return Ok(_proxyRotationService.Rotate(req.url));
        }
    }
} 
