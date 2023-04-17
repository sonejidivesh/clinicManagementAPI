using PrescriptionGeneration.Model;
using System.Text.Json.Serialization;

namespace PrescriptionGeneration.APIModel
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public List<MedicationPrescribedModel>? medicationPrescribedModels { get; set; }

        public List<VacinationPrescribedModel>? vacinationPrescribedModels { get; set; }

        public List<MedicalTestPrescribedModel>? medicalTestPrescribedModels { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
