using PrescriptionGeneration.Model;
using System.Text.Json.Serialization;

namespace PrescriptionGeneration.APIModel
{
    public class VacinationPrescribedModel
    {
        public int VacinationId { get; set; }
        public double Dose { get; set; }

    }
}
