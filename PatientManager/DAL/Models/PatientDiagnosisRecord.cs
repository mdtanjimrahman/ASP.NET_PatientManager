namespace DAL.Models
{
    public class PatientDiagnosisRecord
    {
        public string PatientName { get; set; }
        public string DiagnosisDetails { get; set; }
        public string DiagnosisDate { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}