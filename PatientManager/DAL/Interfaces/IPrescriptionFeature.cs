using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPrescriptionFeature
    {
        List<Prescription> GetByPatient(int patientId);
        List<Prescription> GetByDoctor(int doctorId);
    }
}
