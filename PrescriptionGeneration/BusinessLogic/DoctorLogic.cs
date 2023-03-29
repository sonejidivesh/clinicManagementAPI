using Microsoft.EntityFrameworkCore;
using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.BusinessLogic
{
    public class DoctorLogic
    {
        private readonly ClinicDbContext _context;
        public DoctorLogic(ClinicDbContext context)
        {
            _context = context;
        }

        public async Task<Doctor> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Doctor>> GetList()
        {
            try
            {
                return await _context.Doctors.Include(s=>s.Specilazation)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return new List<Doctor>();
            }


        }

        public async Task<Doctor> GetDoctor(int id)
        {
            try
            {
                return await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
                  
            }
            catch (Exception ex)
            {
                return new Doctor();
            }


        }

        public async Task<Doctor> Post(Doctor request)
        {
            try
            {
                 await _context.Doctors.AddAsync(request);
                _context.SaveChangesAsync();
                return request;

            }catch (Exception ex)
            {
                return new Doctor();
            }
        }

        public Doctor Update(Doctor request)
        {
            throw new NotImplementedException();
        }
    }
}
