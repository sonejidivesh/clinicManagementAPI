using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.APIModel;
using PrescriptionGeneration.BusinessLogic;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        private readonly ClinicDbContext _context;
        public MedicationController(ClinicDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult SetMedication([FromBody] List<MedicationPrescribedModel> medicationPrescribed)
        {
            var medicationPre = new MedicationBusinessLogic(_context);
            //medicationPre.SetMedicationPrescribed(medicationPrescribed);
            return Ok(medicationPre);


        }

    }
}
