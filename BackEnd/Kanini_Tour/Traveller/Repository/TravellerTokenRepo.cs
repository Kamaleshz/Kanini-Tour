using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Travellers.Context;
using Travellers.Interface;
using Travellers.Models;

namespace Travellers.Services
{
    public class TravellerTokenRepo : ITravellerToken
    {
        private readonly TravellerContext _context;
        private readonly IConfiguration _configuration;

        public TravellerTokenRepo(TravellerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IEnumerable<Traveller> GetTravellers()
        {
            return _context.Travellers.ToList();
        }

        public async Task<Traveller> GetTravellerByEmailAndPassword(string email, string password)
        {
            return await _context.Travellers.FirstOrDefaultAsync(x => x.Traveller_Email == email && x.Traveller_Password == password);
        }

        public string GenerateJwtToken(Traveller traveller)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Traveller_Id", traveller.Traveller_Id.ToString()),
                new Claim("Traveller_Email", traveller.Traveller_Email),
                new Claim(ClaimTypes.Role, "Traveller")
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
