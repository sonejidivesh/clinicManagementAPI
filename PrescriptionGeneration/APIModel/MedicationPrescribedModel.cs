namespace PrescriptionGeneration.APIModel
{
    public class MedicationPrescribedModel
    {

        public int Id { get; set; }

        public int MedicationId { get; set; }

        public double Dosage { get; set; }

        public int PrescriptionId { get; set; }
    }
}
