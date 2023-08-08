using Admins.Context;
using Admins.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Admins.Controllers
{
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly AdminContextClass _context;

        private const string AdminRole = "Admin";

        public TokenController(IConfiguration config, AdminContextClass context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("Admin")]
        public async Task<IActionResult> PostStaff(Model.Admins staffData)
        {
            if (staffData != null && !string.IsNullOrEmpty(staffData.Admin_Email) && !string.IsNullOrEmpty(staffData.Admin_Password))
            {
                if (staffData.Admin_Email == "Madara@gmail.com" && staffData.Admin_Password == "Madara@123")
                {
                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Admin_Id", "1"),
                new Claim("Admin_Email", staffData.Admin_Email),
                new Claim("Admin_Password", staffData.Admin_Password),
                new Claim(ClaimTypes.Role, AdminRole)
            };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:ValidIssuer"],
                        _configuration["Jwt:ValidAudience"],
                        claims,
                        expires: DateTime.UtcNow.AddDays(1),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
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
