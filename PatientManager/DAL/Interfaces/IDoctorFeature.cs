using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IDoctorFeature
    {
        List<Doctor> GetBySpecialization(string specialization);
        Doctor GetByEmail(string email);
    }
}
