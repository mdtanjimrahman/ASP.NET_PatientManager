using System;

namespace BLL.DTOs
{
    public class PrescriptionDTO
    {
        public int PrescriptionID { get; set; }
        public int PatientID { get; set; }
        public int DoctorID { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public List<MedicationDTO> Medications { get; set; }
    }
}
