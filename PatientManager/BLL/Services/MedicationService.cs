using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class MedicationService
    {
        Repository<Medication> repo;
        IMedicationFeature featureRepo;

        public MedicationService(Repository<Medication> repo, IMedicationFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        public List<MedicationDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<MedicationDTO>>(data);
        }

        public MedicationDTO GetById(int id)
        {
            var m = repo.Get(id);
            return MapperConfig.GetMapper().Map<MedicationDTO>(m);
        }

        public bool Create(MedicationDTO dto)
        {
            var m = MapperConfig.GetMapper().Map<Medication>(dto);
            return repo.Create(m);
        }

        public bool Update(MedicationDTO dto)
        {
            var m = MapperConfig.GetMapper().Map<Medication>(dto);
            return repo.Update(m);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        //Feature

        public List<MedicationDTO> GetByPrescription(int prescriptionId)
        {
            var data = featureRepo.GetByPrescription(prescriptionId);
            return data.Select(m => MapperConfig.GetMapper().Map<MedicationDTO>(m)).ToList();
        }

        public List<MedicationDTO> GetByName(string name)
        {
            var data = featureRepo.GetByName(name);
            return data.Select(m => MapperConfig.GetMapper().Map<MedicationDTO>(m)).ToList();
        }
    }
}
