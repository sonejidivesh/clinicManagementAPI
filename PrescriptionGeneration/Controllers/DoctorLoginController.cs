using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.APIModel;
using PrescriptionGeneration.BusinessLogic;
using PrescriptionGeneration.Interface;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorLoginController : ControllerBase
    {
        //private readonly IJwtTokenManager _tokenManager;
        private ClinicDbContext _context;

        public DoctorLoginController(ClinicDbContext context)
        {
            //_tokenManager = tokenManager;
            _context = context;
            
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]DoctorLoginModel doctor)
        {
            var userdetials = _context.DoctorLogins.Include(d => d.DoctorDetails).FirstOrDefault(x => x.DoctorName == doctor.DoctorName && x.Password == doctor.Password);
            //var token = _tokenManager.Authenicate(doctor.DoctorName, doctor.Password);
            if (userdetials is null) {
             return Unauthorized();
            }

            return Ok(userdetials);
         }
    }
}
