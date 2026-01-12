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
    public class DiagnosisService
    {
        DataAccessFactory fact;

        public DiagnosisService(DataAccessFactory fact)
        {
            this.fact = fact;
        }


        public List<DiagnosisDTO> GetAll()
        {
            var data = fact.GetRepo<Diagnosis>().Get();
            return MapperConfig.GetMapper().Map<List<DiagnosisDTO>>(data);
        }

        public DiagnosisDTO GetById(int id)
        {
            var data = fact.GetRepo<Diagnosis>().Get(id);
            return MapperConfig.GetMapper().Map<DiagnosisDTO>(data);
        }

        public bool Create(DiagnosisDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<Diagnosis>(dto);
            return fact.GetRepo<Diagnosis>().Create(entity);
        }

        public bool Update(DiagnosisDTO dto)
        {
            var entity = MapperConfig.GetMapper().Map<Diagnosis>(dto);
            return fact.GetRepo<Diagnosis>().Update(entity);
        }

        public bool Delete(int id)
        {
            return fact.GetRepo<Diagnosis>().Delete(id);
        }


        //Feature
        public List<DiagnosisDTO> GetByPatient(int patientId)
        {
            var data = fact.DiagnosisFeature().GetByPatient(patientId);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }

        public List<DiagnosisDTO> GetByDoctor(int doctorId)
        {
            var data = fact.DiagnosisFeature().GetByDoctor(doctorId);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }

        public List<DiagnosisDTO> GetRecentDiagnoses(int days)
        {
            var data = fact.DiagnosisFeature().GetRecentDiagnoses(days);
            return data.Select(d => MapperConfig.GetMapper().Map<DiagnosisDTO>(d)).ToList();
        }
    }
}
