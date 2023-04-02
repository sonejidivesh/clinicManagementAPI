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
        public virtual DoctorAppointment Appointment { get; set; }
        public virtual ICollection<MedicationPrescribed> MedicationPrescribed { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
