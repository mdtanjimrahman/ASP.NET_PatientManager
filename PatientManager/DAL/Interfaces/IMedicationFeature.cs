using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IMedicationFeature
    {
        List<Medication> GetByPrescription(int prescriptionId);
        List<Medication> GetByName(string name);
    }
}
