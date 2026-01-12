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
    public class PrescriptionService
    {
        DataAccessFactory factory;

        public PrescriptionService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<PrescriptionDTO> GetAll()
        {
            var data = factory.GetRepo<Prescription>().Get();
            return MapperConfig.GetMapper().Map<List<PrescriptionDTO>>(data);
        }

        public PrescriptionDTO Get(int id)
        {
            var data = factory.GetRepo<Prescription>().Get(id);
            return MapperConfig.GetMapper().Map<PrescriptionDTO>(data);
        }

        public bool Create(PrescriptionDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Prescription>(dto);
            return factory.GetRepo<Prescription>().Create(ex);
        }

        public bool Update(PrescriptionDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Prescription>(dto);
            return factory.GetRepo<Prescription>().Update(ex);
        }

        public bool Delete(int id)
        {
            return factory.GetRepo<Prescription>().Delete(id);
        }


        //Feature
        public List<PrescriptionDTO> GetByPatient(int patientId)
        {
            var data = factory.PrescriptionFeature().GetByPatient(patientId);
            return data.Select(p => MapperConfig.GetMapper().Map<PrescriptionDTO>(p)).ToList();
        }

        public List<PrescriptionDTO> GetByDoctor(int doctorId)
        {
            var data = factory.PrescriptionFeature().GetByDoctor(doctorId);
            return data.Select(p => MapperConfig.GetMapper().Map<PrescriptionDTO>(p)).ToList();
        }
    }
}
