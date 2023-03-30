﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.APIModel;
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
            public async Task<IActionResult> BookAppointment([FromBody] AppointmentModel appointment)
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
                    return BadRequest("Doctor not found.!");
                }

                _context.Entry(doctor).State=Microsoft.EntityFrameworkCore.EntityState.Detached;
            // Add the appointment to the database
                var docApp = new DoctorAppointment
                {
                    DoctorId = appointment.DoctorId,
                    PatientName = appointment.PatientName,
                    AppointmentDateTime = appointment.AppointmentDateTime,
                    AppointmentNotes = appointment.AppointmentNotes,
                    AppointmentReason = appointment.AppointmentReason,
                };    

                _context.Appointments.Add(docApp);
                await _context.SaveChangesAsync();

                return Ok(new {  message="Appointment booked successfully." , appointmentDetails = appointment});
            }

            [HttpGet]
            public async Task<ActionResult<List<DoctorAppointment>>> Get()
            {

                var appointmentList = await _context.Appointments.Where(x=>(x.AppointmentDateTime.Date == DateTime.Today) ).ToListAsync();

                return Ok(appointmentList);

            }



    }
}