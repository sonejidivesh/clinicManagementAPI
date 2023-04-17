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

        public void SetVacinePrescribed(List<VacinationPrescribedModel> model, int prescriptionId)
        {

            List<VacinationPrescribed> test = new List<VacinationPrescribed>();

            foreach (VacinationPrescribedModel m in model)
            {

                test.Add(new VacinationPrescribed
                {
                   VacinationId = m.VacinationId,
                   Dose = m.Dose,
                    PrescriptionId = prescriptionId,

                });
            }

            _context.AddRange(test);

            _context.SaveChanges();

        }
        
        public void SetMedicalTestPrescribed(List<MedicalTestPrescribedModel> model, int prescriptionId)
        {

            List<MedicalTestPrescribed> test = new List<MedicalTestPrescribed>();

            foreach (MedicalTestPrescribedModel m in model)
            {

                test.Add(new MedicalTestPrescribed
                {
                    TestId= m.TestId,
                    PrescriptionId = prescriptionId,

                });
            }

            _context.AddRange(test);

            _context.SaveChanges();

        }



    }
}
