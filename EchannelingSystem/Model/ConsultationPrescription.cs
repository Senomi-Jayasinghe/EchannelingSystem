namespace EchannelingSystem.Model
{
    public class ConsultationPrescription
    {
        public int prescriptionID {  get; set; }
        public int consultationID { get; set; }
        public int diseaseID { get; set; }
        public int medicineID { get; set; }

    }
}
