using PrescriptionGeneration.Model;

namespace PrescriptionGeneration.APIModel
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }

        public List<MedicationPrescribedModel> medicationPrescribedModels { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
