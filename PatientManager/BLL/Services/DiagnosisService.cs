using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class DiagnosisService
    {
        Repository<Diagnosis> repo;
        IDiagnosisFeature featureRepo;

        public DiagnosisService(Repository<Diagnosis> repo, IDiagnosisFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        public List<DiagnosisDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<DiagnosisDTO>>(data);
        }

        public DiagnosisDTO GetById(int id)
        {
            var d = repo.Get(id);
            return MapperConfig.GetMapper().Map<DiagnosisDTO>(d);
        }

        public bool Create(DiagnosisDTO dto)
        {
            var d = MapperConfig.GetMapper().Map<Diagnosis>(dto);
            return repo.Create(d);
        }

        public bool Update(DiagnosisDTO dto)
        {
            var d = MapperConfig.GetMapper().Map<Diagnosis>(dto);
            return repo.Update(d);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }


        //Feature
        public List<DiagnosisDTO> GetByPatient(int patientId)
        {
            var data = featureRepo.GetByPatient(patientId);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }

        // Get all diagnoses by a doctor
        public List<DiagnosisDTO> GetByDoctor(int doctorId)
        {
            var data = featureRepo.GetByDoctor(doctorId);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }

        public List<DiagnosisDTO> GetRecentDiagnoses(int days)
        {
            var data = featureRepo.GetRecentDiagnoses(days);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }
    }
}
