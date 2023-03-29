using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
            private readonly ClinicDbContext _context;

            public AppointmentController(ClinicDbContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> BookAppointment([FromBody] DoctorAppointment appointment)
            {
                // Check if the appointment is valid
                if (appointment == null)
                {
                    return BadRequest();
                }

                // Check if the doctor exists
                var doctor = await _context.Doctors.FindAsync(appointment.DoctorId);
                if (doctor == null)
                {
                    return BadRequest("Doctor not found.");
                }

                // Add the appointment to the database
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                return Ok("Appointment booked successfully.");
            }
        




    }
}
