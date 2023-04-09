using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PrescriptionGeneration.Model
{

    public class Doctor
    {

        //  public int Id { get; set; }
        public int Id { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public int Experience { get; set; }

        public byte? Gender { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Specilazation { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        //public DoctorLogin DoctorLoginDetail { get; set; }


    }
}
