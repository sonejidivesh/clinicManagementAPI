using System.Text.Json.Serialization;

namespace PrescriptionGeneration.Model
{
    public class MedicalTestPrescribed
    {
        public int Id { get; set; }

        public int TestId { get; set; }

        public int PrescriptionId { get; set; }

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }

    }
}
