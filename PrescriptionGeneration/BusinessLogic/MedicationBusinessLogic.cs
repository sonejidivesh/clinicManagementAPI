using PrescriptionGeneration.APIModel;
using PrescriptionGeneration.Model; 

namespace PrescriptionGeneration.BusinessLogic
{
    public class MedicationBusinessLogic
    {
        private ClinicDbContext _context;
        public MedicationBusinessLogic(ClinicDbContext context)
        {

            _context = context;

        }



        public void SetMedicationPrescribed (List<MedicationPrescribedModel> model , int prescriptionId)
        {

            List<MedicationPrescribed> test =  new List<MedicationPrescribed> ();

            foreach (MedicationPrescribedModel m in model)
            {

                test.Add(new MedicationPrescribed
                {
                    Id = m.Id,
                    MedicationId = m.MedicationId,
                    Dosage = m.Dosage,
                    Frequency = m.Frequency,
                    PrescriptionId = prescriptionId,

                });
            }

            _context.AddRange(test);

            _context.SaveChanges();
            //_context.BulkInsert(test);

        }
    }
}
