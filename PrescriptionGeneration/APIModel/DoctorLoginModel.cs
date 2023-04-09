using System.ComponentModel.DataAnnotations;

namespace PrescriptionGeneration.APIModel
{
    public class DoctorLoginModel
    {
        public int Id { get; set; }

        public string DoctorName { get; set; }

        public string Password { get; set; }

    
    }
}
