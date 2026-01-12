using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PatientService
    {
        DataAccessFactory factory;

        public PatientService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        //crud
        public List<PatientDTO> GetAll()
        {
            var data = factory.GetRepo<Patient>().Get();
            return MapperConfig.GetMapper().Map<List<PatientDTO>>(data);
        }

        public PatientDTO Get(int id)
        {
            var data = factory.GetRepo<Patient>().Get(id);
            return MapperConfig.GetMapper().Map<PatientDTO>(data);
        }

        public bool Create(PatientDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Patient>(dto);
            return factory.GetRepo<Patient>().Create(ex);
        }

        public bool Update(PatientDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Patient>(dto);
            return factory.GetRepo<Patient>().Update(ex);
        }

        public bool Delete(int id)
        {
            return factory.GetRepo<Patient>().Delete(id);
        }


        //Feature
        public PatientDTO GetByEmail(string email)
        {
            var data = factory.PatientFeature().GetByEmail(email);
            return MapperConfig.GetMapper().Map<PatientDTO>(data);
        }

        public List<PatientDTO> GetByGender(string gender)
        {
            var data = factory.PatientFeature().GetByGender(gender);
            return data.Select(p => MapperConfig.GetMapper().Map<PatientDTO>(p)).ToList();
        }
    }
}
