namespace PrescriptionGeneration.Model
{
    public class Prescription
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }
        public virtual DoctorAppointment Appointment { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
