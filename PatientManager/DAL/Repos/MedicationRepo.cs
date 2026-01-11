using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repos
{
    internal class MedicationRepo : Repository<Medication>, IMedicationFeature
    {
        public MedicationRepo(PMContext db) : base(db) { }

        public List<Medication> GetByPrescription(int prescriptionId)
        {
            var data = (from m in db.Medications
                        where m.PrescriptionID == prescriptionId
                        select m).ToList();

            return data;
        }

        public List<Medication> GetByName(string name)
        {
            var data = (from m in db.Medications
                        where m.MedicationName.Contains(name)
                        select m).ToList();

            return data;
        }
    }
}
