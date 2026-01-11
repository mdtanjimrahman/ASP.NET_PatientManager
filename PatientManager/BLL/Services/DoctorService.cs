using BLL.DTOs;
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
        Repository<Doctor> repo;
        IDoctorFeature featureRepo;

        public DoctorService(Repository<Doctor> repo, IDoctorFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        public List<DoctorDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<DoctorDTO>>(data);
        }

        public DoctorDTO GetById(int id)
        {
            var d = repo.Get(id);
            return MapperConfig.GetMapper().Map<DoctorDTO>(d);
        }

        public bool Create(DoctorDTO dto)
        {
            var d = MapperConfig.GetMapper().Map<Doctor>(dto);
            return repo.Create(d);
        }

        public bool Update(DoctorDTO dto)
        {
            var d = MapperConfig.GetMapper().Map<Doctor>(dto);
            return repo.Update(d);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }

        //Feature
        public List<DoctorDTO> GetBySpecialization(string specialization)
        {
            var data = featureRepo.GetBySpecialization(specialization);
            return data.Select(d => MapperConfig.GetMapper().Map<DoctorDTO>(d)).ToList();
        }

        public DoctorDTO GetByEmail(string email)
        {
            var doctor = featureRepo.GetByEmail(email);
            return MapperConfig.GetMapper().Map<DoctorDTO>(doctor);
        }
    }
}
