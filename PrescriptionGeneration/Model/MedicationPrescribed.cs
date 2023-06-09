﻿using System.Text.Json.Serialization;

namespace PrescriptionGeneration.Model
{
    public class MedicationPrescribed
    {

        public int Id { get; set; }

        public int MedicationId { get; set; }

        public double Dosage { get; set; }

        public int Frequency { get; set; }
        public int PrescriptionId { get; set; }

        [JsonIgnore]
        public virtual Prescription Prescription { get; set; }
    }
}
