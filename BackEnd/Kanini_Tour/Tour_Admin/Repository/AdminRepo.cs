using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tour_Admin.Context;
using Tour_Admin.Interface;
using Tour_Admin.Model;

namespace Tour_Admin.Repository
{
    public class AdminRepo : IAdmin
    {
        private readonly AdminContext _context;
        private readonly IConfiguration _configuration;

        public AdminRepo(AdminContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IEnumerable<Admin> GetTravelAgents()
        {
            return _context.admins.ToList();
        }

        public async Task<Admin> GetAdminByEmailAndPassword(string email, string password)
        {
            return await _context.admins.FirstOrDefaultAsync(x => x.Admin_Email == email && x.Admin_Password == password);
        }

        public string GenerateJwtToken(Admin admin)
        {

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Admin_Email", admin.Admin_Email),
                new Claim(ClaimTypes.Role, "Admin")
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
