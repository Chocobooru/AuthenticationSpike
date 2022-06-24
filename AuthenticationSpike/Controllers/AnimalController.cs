using AuthenticationSpike.JwtToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationSpike.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AnimalController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public string Get()
        {
            return _tokenService.GenerateToken();
        }

        //[Authorize]
        [HttpPost]
        public string Post()
        {
            return "tapino d'ono";
        }


    }
}
