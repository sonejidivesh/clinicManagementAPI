using System.Text.Json.Serialization;

namespace PrescriptionGeneration.Model
{
    public class Prescription
    {

        public Prescription()
        {
            this.MedicationPrescribed = new HashSet<MedicationPrescribed>();
        }
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        [JsonIgnore]
        public virtual DoctorAppointment Appointment { get; set; }
        public virtual ICollection<MedicationPrescribed> MedicationPrescribed { get; set; }
        public virtual ICollection<VacinationPrescribed> VacinationPrescribeds { get; set; }
        public virtual ICollection<MedicalTestPrescribed> MedicalTestPrescribeds { get; set; }
        public DateTime CreatedDate { get; set; }

        public Boolean IsCreated { get; set; } = true;

    }
}
