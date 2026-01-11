using BLL.DTOs;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class AppointmentService
    {
        Repository<Appointment> repo;
        IAppointmentFeature featureRepo;

        public AppointmentService(Repository<Appointment> repo, IAppointmentFeature featureRepo)
        {
            this.repo = repo;
            this.featureRepo = featureRepo;
        }

        // CRUD via generic repo
        public List<AppointmentDTO> GetAll()
        {
            var data = repo.Get();
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
        }

        public AppointmentDTO GetById(int id)
        {
            var a = repo.Get(id);
            return MapperConfig.GetMapper().Map<AppointmentDTO>(a);
        }

        public bool Create(AppointmentDTO dto)
        {
            var a = MapperConfig.GetMapper().Map<Appointment>(dto);
            return repo.Create(a);
        }

        public bool Update(AppointmentDTO dto)
        {
            var a = MapperConfig.GetMapper().Map<Appointment>(dto);
            return repo.Update(a);
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }



        // features via feature repo
        public bool ChangeStatus(int appointmentId, string status)
        {
            return featureRepo.ChangeStatus(appointmentId, status);
        }

        // Get appointments by Doctor
        public List<AppointmentDTO> GetByDoctor(int doctorId)
        {
            var data = featureRepo.GetByDoctor(doctorId);
            return data.Select(a => MapperConfig.GetMapper().Map<AppointmentDTO>(a)).ToList();
        }

        // Get appointments by Patient
        public List<AppointmentDTO> GetByPatient(int patientId)
        {
            var data = featureRepo.GetByPatient(patientId);
            return data.Select(a => MapperConfig.GetMapper().Map<AppointmentDTO>(a)).ToList();
        }
    }
}
