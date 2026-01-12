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
    public class MedicationService
    {
        DataAccessFactory factory;

        public MedicationService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public List<MedicationDTO> GetAll()
        {
            var data = factory.GetRepo<Medication>().Get();
            return MapperConfig.GetMapper().Map<List<MedicationDTO>>(data);
        }

        public MedicationDTO Get(int id)
        {
            var data = factory.GetRepo<Medication>().Get(id);
            return MapperConfig.GetMapper().Map<MedicationDTO>(data);
        }

        public bool Create(MedicationDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Medication>(dto);
            return factory.GetRepo<Medication>().Create(ex);
        }

        public bool Update(MedicationDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Medication>(dto);
            return factory.GetRepo<Medication>().Update(ex);
        }

        public bool Delete(int id)
        {
            return factory.GetRepo<Medication>().Delete(id);
        }


        //Feature

        public List<MedicationDTO> GetByPrescription(int prescriptionId)
        {
            var data = factory.MedicationFeature().GetByPrescription(prescriptionId);
            return data.Select(m => MapperConfig.GetMapper().Map<MedicationDTO>(m)).ToList();
        }

        public List<MedicationDTO> GetByName(string name)
        {
            var data = factory.MedicationFeature().GetByName(name);
            return data.Select(m => MapperConfig.GetMapper().Map<MedicationDTO>(m)).ToList();
        }
    }
}
