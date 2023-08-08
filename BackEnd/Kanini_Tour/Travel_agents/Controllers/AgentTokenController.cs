using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tour_Package.Interface;
using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Tour_Package.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentTokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAgentToken _agentTokenService;

        public AgentTokenController(IConfiguration configuration, IAgentToken agentTokenService)
        {
            _configuration = configuration;
            _agentTokenService = agentTokenService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(Login login) // Use Login DTO as parameter
        {
            if (ModelState.IsValid)
            {
                var travelAgent = await _agentTokenService.GetTravelAgentByEmailAndPassword(login.Email, login.Password);

                if (travelAgent != null)
                {
                    var token = _agentTokenService.GenerateJwtToken(travelAgent);

                    var response = new
                    {
                        token,
                        travelagent_Id = travelAgent.Travelagent_Id
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
                return BadRequest(ModelState);
            }
        }
    }
}
