using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescription(int id)
        {
            Prescription? p = await _context.Prescriptions.Include(x => x.MedicationPrescribed )
                .Include(m=> m.MedicalTestPrescribeds)
                .Include(v=>v.VacinationPrescribeds)
                .OrderByDescending(p => p.Id).FirstOrDefaultAsync(x => x.AppointmentId == id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }


        [HttpPost]
        public async Task<IActionResult> PostPrescripion([FromBody] PrescriptionModel prescriptionModel )
        {

            var medicationPre = new MedicationBusinessLogic(_context);
            var prescription = new Prescription();
            //prescription.Id = prescriptionModel.Id;
            prescription.DoctorId = prescriptionModel.DoctorId;
            prescription.AppointmentId = prescriptionModel.AppointmentId;
            prescription.PatientName = prescriptionModel.PatientName;
            prescription.IsCreated = true;
            _context.Add( prescription );
            await _context.SaveChangesAsync();
            if (prescriptionModel.medicationPrescribedModels != null )
            {
                medicationPre.SetMedicationPrescribed(prescriptionModel.medicationPrescribedModels, prescription.Id);

            }
            if (prescriptionModel.vacinationPrescribedModels != null)
            {
                medicationPre.SetVacinePrescribed(prescriptionModel.vacinationPrescribedModels, prescription.Id);

            }

            if (prescriptionModel.medicalTestPrescribedModels != null)
            {
                medicationPre.SetMedicalTestPrescribed(prescriptionModel.medicalTestPrescribedModels, prescription.Id);

            }


            return Ok(new { message = "Precription saved successfully.", prescriptionDetails = prescription });
        }


    }
}
