namespace BLL.DTOs
{
    public class MedicationDTO
    {
        public int MedicationID { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
        public int PrescriptionID { get; set; }
    }
}