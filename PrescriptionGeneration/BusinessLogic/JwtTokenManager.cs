using Microsoft.IdentityModel.Tokens;
using PrescriptionGeneration.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace PrescriptionGeneration.BusinessLogic
{
    public class JwtTokenManager : IJwtTokenManager
    {
        private readonly IConfiguration _configuration;
        private ClinicDbContext _context;
        public JwtTokenManager(IConfiguration configuration , ClinicDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        public string Authenicate(string doctorName, string password)
        {
            var userdetials = _context.DoctorLogins.Include(d => d.DoctorDetails).FirstOrDefault(x => x.DoctorName == doctorName && x.Password == password);
            if (userdetials == null)
            {
                return null;
            }

            var key = _configuration.GetValue<string>("JwtConfig:Key");

            var keyByte =  Encoding.ASCII.GetBytes(key);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, doctorName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyByte), SecurityAlgorithms.HmacSha256),

            };

            var token  =  tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
            
        }
    }
}
