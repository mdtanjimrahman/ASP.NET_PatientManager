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
    public class DoctorService
    {
        DataAccessFactory factory;

        public DoctorService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<DoctorDTO> GetAll()
        {
            var data = factory.GetRepo<Doctor>().Get();
            return MapperConfig.GetMapper().Map<List<DoctorDTO>>(data);
        }

        public DoctorDTO Get(int id)
        {
            var data = factory.GetRepo<Doctor>().Get(id);
            return MapperConfig.GetMapper().Map<DoctorDTO>(data);
        }

        public bool Create(DoctorDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Doctor>(dto);
            return factory.GetRepo<Doctor>().Create(ex);
        }

        public bool Update(DoctorDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Doctor>(dto);
            return factory.GetRepo<Doctor>().Update(ex);
        }

        public bool Delete(int id)
        {
            return factory.GetRepo<Doctor>().Delete(id);
        }

        //Feature
        public List<DoctorDTO> GetBySpecialization(string specialization)
        {
            var data = factory.DoctorFeature().GetBySpecialization(specialization);
            return data.Select(d => MapperConfig.GetMapper().Map<DoctorDTO>(d)).ToList();
        }

        public DoctorDTO GetByEmail(string email)
        {
            var data = factory.DoctorFeature().GetByEmail(email);
            return MapperConfig.GetMapper().Map<DoctorDTO>(data);
        }
    }
}
