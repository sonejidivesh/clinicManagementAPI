using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorLoginController : ControllerBase
    {
        private ClinicDbContext _context;
        public DoctorLoginController(ClinicDbContext  context)
        {
            _context = context;
            
        }


        [HttpPost]
        public async Task<ActionResult<bool>> Login(DoctorLogin doctor)
        {
            var foundDoctor = await _context.DoctorLogins.FirstOrDefaultAsync(d => d.DoctorName == doctor.DoctorName && d.Password == doctor.Password);
            if (foundDoctor != null)
            {
                // Successful login
                return true;
            }
            else
            {
                // Failed login
                return false;
            }
        }
    }
}
