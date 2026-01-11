using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class PatientRepo : Repository<Patient>, IPatientFeature
    {
        public PatientRepo(PMContext db) : base(db) { }

        public Patient GetByEmail(string email)
        {
            var data = (from p in db.Patients
                        where p.Email == email
                        select p).FirstOrDefault();

            return data;
        }

        public List<Patient> GetByGender(string gender)
        {
            var data = (from p in db.Patients
                        where p.Gender == gender
                        select p).ToList();

            return data;
        }
    }
}
