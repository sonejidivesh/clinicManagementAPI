namespace PrescriptionGeneration.Model
{
    public class DoctorAppointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public DateTime AppointmentDateTime { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string AppointmentReason { get; set; } = string.Empty;
        public string AppointmentNotes { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }

}
