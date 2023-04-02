using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PrescriptionGeneration.Model;
using System.Reflection.Metadata;


namespace PrescriptionGeneration
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }


        public DbSet<DoctorAppointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<MedicationPrescribed> MedicationPrescribeds { get; set; }

        public DbSet<DoctorLogin> DoctorLogins { get; set; }


    }
}
