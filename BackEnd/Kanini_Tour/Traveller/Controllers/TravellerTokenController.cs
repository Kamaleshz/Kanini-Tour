using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Travellers.Interface;
using Travellers.Models;

namespace Travellers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerTokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITravellerToken _travellers;

        public TravellerTokenController(IConfiguration configuration, ITravellerToken travellers)
        {
            _configuration = configuration;
            _travellers = travellers;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(Traveller _userData)
        {
            if (_userData != null && !string.IsNullOrEmpty(_userData.Traveller_Email) && !string.IsNullOrEmpty(_userData.Traveller_Password))
            {
                var traveller = await _travellers.GetTravellerByEmailAndPassword(_userData.Traveller_Email, _userData.Traveller_Password);

                if (traveller != null)
                {
                    var token = _travellers.GenerateJwtToken(traveller);

                    var response = new
                    {
                        token,
                        traveller_Id = traveller.Traveller_Id
                    };

                    return Ok(response);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
