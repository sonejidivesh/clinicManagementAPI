using System.ComponentModel.DataAnnotations;

namespace PrescriptionGeneration.Model
{
    public class DoctorLogin
    {


        public int Id { get; set; }

        [Required]
        public string DoctorName { get; set; }

        [Required]
        public string Password { get; set; }

        public int? DoctorId { get; set; }

        public virtual Doctor DoctorDetails { get; set; }
    }
}
