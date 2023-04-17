using System.Text.Json.Serialization;

namespace PrescriptionGeneration.Model
{
    public class VacinationPrescribed
    {

        public int Id { get; set; }
        public int VacinationId { get; set; }
        public double Dose { get; set; }

        public int PrescriptionId { get; set; }

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }
    }
}
