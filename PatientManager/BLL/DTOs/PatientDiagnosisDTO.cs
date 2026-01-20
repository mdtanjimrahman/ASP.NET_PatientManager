using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class PatientDiagnosisDTO
    {
        public string PatientName { get; set; }
        public string DiagnosisDetails { get; set; }
        public string DiagnosisDate { get; set; }
        public string MedicationName { get; set; }
        public string Dosage { get; set; }
        public string Duration { get; set; }
    }
}
