using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class DoctorRepo : Repository<Doctor>, IDoctorFeature
    {
        public DoctorRepo(PMContext db) : base(db) { }

        //crud via base repo

        // get doctors info by specialization category
        public List<Doctor> GetBySpecialization(string specialization)
        {
            var data = (from d in db.Doctors
                        where d.Specialization == specialization
                        select d).ToList();

            return data;
        }

        // get doctor info by email address
        public Doctor GetByEmail(string email)
        {
            var data = (from d in db.Doctors
                        where d.Email == email
                        select d).FirstOrDefault();

            return data;
        }
    }
}
