using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tour_Package.Context;
using Tour_Package.Interface;
using Tour_Package.Models;
using Tour_Package.Models.DTO;

namespace Tour_Package.Repository
{
    public class AgentTokenRepo : IAgentToken
    {
        private readonly AgentContext _context;
        private readonly IConfiguration _configuration;

        public AgentTokenRepo(AgentContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IEnumerable<Travel_agent> GetTravelAgents()
        {
            return _context.travel_agents.ToList();
        }

        public async Task<Travel_agent> GetTravelAgentByEmailAndPassword(string email, string password)
        {
            return await _context.travel_agents.FirstOrDefaultAsync(x => x.Travelagent_Email == email && x.Travelagent_Password == password);
        }

        public string GenerateJwtToken(Travel_agent travelAgent)
        {
            if (travelAgent.Travelagent_Status != "Accepted")
            {
                throw new InvalidOperationException("Travel agent is not accepted.");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("TravelAgent_Id", travelAgent.Travelagent_Id.ToString()),
                new Claim("TravelAgent_Email", travelAgent.Travelagent_Email),
                new Claim(ClaimTypes.Role, "TravelAgent")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:ValidIssuer"],
                _configuration["Jwt:ValidAudience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
