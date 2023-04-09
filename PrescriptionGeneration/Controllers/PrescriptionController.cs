using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrescriptionGeneration.APIModel;
using PrescriptionGeneration.BusinessLogic;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private ClinicDbContext _context;

        public PrescriptionController(ClinicDbContext context)
        {

            _context = context;

        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PrescriptionModel prescriptionModel )
        {

            var medicationPre = new MedicationBusinessLogic(_context);
            var prescription = new Prescription();
            //prescription.Id = prescriptionModel.Id;
            prescription.DoctorId = prescriptionModel.DoctorId;
            prescription.AppointmentId = prescriptionModel.AppointmentId;
            prescription.PatientName = prescriptionModel.PatientName;
           
            _context.Add( prescription );
            await _context.SaveChangesAsync();
            medicationPre.SetMedicationPrescribed(prescriptionModel.medicationPrescribedModels,prescription.Id);

            return Ok();
        }


    }
}
