using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class PrescriptionService
    {
        Repository<Prescription> repo;
        IPrescriptionFeature featureRepo;

        public PrescriptionService(Repository<Prescription> repo, IPrescriptionFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        public List<PrescriptionDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<PrescriptionDTO>>(data);
        }

        public PrescriptionDTO GetById(int id)
        {
            var p = repo.Get(id);
            return MapperConfig.GetMapper().Map<PrescriptionDTO>(p);
        }

        public bool Create(PrescriptionDTO dto)
        {
            var p = MapperConfig.GetMapper().Map<Prescription>(dto);
            return repo.Create(p);
        }

        public bool Update(PrescriptionDTO dto)
        {
            var p = MapperConfig.GetMapper().Map<Prescription>(dto);
            return repo.Update(p);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        //Feature
        public List<PrescriptionDTO> GetByPatient(int patientId)
        {
            var data = featureRepo.GetByPatient(patientId);
            return data.Select(p => MapperConfig.GetMapper().Map<PrescriptionDTO>(p)).ToList();
        }

        public List<PrescriptionDTO> GetByDoctor(int doctorId)
        {
            var data = featureRepo.GetByDoctor(doctorId);
            return data.Select(p => MapperConfig.GetMapper().Map<PrescriptionDTO>(p)).ToList();
        }
    }
}
