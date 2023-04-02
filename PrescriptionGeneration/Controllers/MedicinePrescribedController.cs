using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinePrescribedController : ControllerBase
    {
        private ClinicDbContext _context;
        public MedicinePrescribedController(ClinicDbContext context)
        {

            _context = context;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<MedicationPrescribed>>> GetMedicationPrescribed(int id)
        {
            List<MedicationPrescribed> _medications = await _context.MedicationPrescribeds.Where(x=>x.PrescriptionId == id).ToListAsync();

            return _medications;
        }

    }
}
