using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tour_Admin.Interface;
using Tour_Admin.Model;

namespace Tour_Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAdmin _agentTokenService;

        public AdminController(IConfiguration configuration, IAdmin agentTokenService)
        {
            _configuration = configuration;
            _agentTokenService = agentTokenService;
        }

        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(Admin login) // Use Login DTO as parameter
        {
            if (ModelState.IsValid)
            {
                var travelAgent = await _agentTokenService.GetAdminByEmailAndPassword(login.Admin_Email, login.Admin_Password);

                if (travelAgent != null)
                {
                    var token = _agentTokenService.GenerateJwtToken(travelAgent);

                    return Ok(token);
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
