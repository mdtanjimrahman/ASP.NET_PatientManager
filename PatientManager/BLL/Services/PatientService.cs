using BLL.DTOs;
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
        Repository<Patient> repo;
        IPatientFeature featureRepo;

        public PatientService(Repository<Patient> repo, IPatientFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        //crud
        public List<PatientDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<PatientDTO>>(data);
        }

        public PatientDTO GetById(int id)
        {
            var p = repo.Get(id);
            return MapperConfig.GetMapper().Map<PatientDTO>(p);
        }

        public bool Create(PatientDTO dto)
        {
            var p = MapperConfig.GetMapper().Map<Patient>(dto);
            return repo.Create(p);
        }

        public bool Update(PatientDTO dto)
        {
            var p = MapperConfig.GetMapper().Map<Patient>(dto);
            return repo.Update(p);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        //Feature
        public PatientDTO GetByEmail(string email)
        {
            var p = featureRepo.GetByEmail(email);
            return MapperConfig.GetMapper().Map<PatientDTO>(p);
        }

        // Get all patients by Gender
        public List<PatientDTO> GetByGender(string gender)
        {
            var data = featureRepo.GetByGender(gender);
            return data.Select(p => MapperConfig.GetMapper().Map<PatientDTO>(p)).ToList();
        }
    }
}
