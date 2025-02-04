using Aforo255.Cross.Token.Src;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MSFercorp.Seguridad.DTOs;
using MSFercorp.Seguridad.Services;

namespace MSFercorp.Seguridad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUsuarioService _accessService;
        private readonly JwtOptions _jwtOption;
        public AuthController(IUsuarioService accessService,
            IOptionsSnapshot<JwtOptions> jwtOption)
        {
            _accessService = accessService;
            _jwtOption = jwtOption.Value;
        }

        public IActionResult Get()
        {
            return Ok(_accessService.GetAllUsuarios());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest request)
        {
            if (!_accessService.Validate(request.UserName, request.Password))
            {
                return Unauthorized();
            }

            Response.Headers.Add("access-control-expose-headers", "Authorization");
            Response.Headers.Add("Authorization", JwtToken.Create(_jwtOption));

            return Ok();
            //return Ok(new { token =  JwtToken.Create(_jwtOption) });
        }
        
    }
}
