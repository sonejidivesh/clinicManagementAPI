using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.BusinessLogic;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorLogic _doctorLogic;

        public DoctorController(ClinicDbContext context)
        {
            _doctorLogic = new DoctorLogic(context);

        }


        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {

            var list = await _doctorLogic.GetList();
            return Ok(list);
        }

        [HttpGet("{id}"),]
        public async Task<ActionResult<Doctor>> Get(int id)
        {

            var detail = await _doctorLogic.GetDoctor(id);
            return Ok(detail);
        }
        [HttpPost]
        public async Task<ActionResult<Doctor>> Post(Doctor request)
        {

            var addDoctor = await _doctorLogic.Post(request);
            return Ok(addDoctor);
        }

    }
}
