using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPatientFeature
    {
        Patient GetByEmail(string email);
        List<Patient> GetByGender(string gender);
    }
}
