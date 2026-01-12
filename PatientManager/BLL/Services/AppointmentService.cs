using BLL.DTOs;
using BLL.Helpers;
using DAL;
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
        DataAccessFactory factory;

        public AppointmentService(DataAccessFactory factory)
        {
            this.factory = factory;
        }


        // CRUD via generic repository
        public List<AppointmentDTO> GetAll()
        {
            var data = factory.GetRepo<Appointment>().Get();
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
        }

        public AppointmentDTO GetById(int id)
        {
            var data = factory.GetRepo<Appointment>().Get(id);
            return MapperConfig.GetMapper().Map<AppointmentDTO>(data);
        }

        public bool Create(AppointmentDTO dto)
        {
            dto.Status = "Scheduled";

            var ex = MapperConfig.GetMapper().Map<Appointment>(dto);
            return factory.GetRepo<Appointment>().Create(ex);
        }

        public bool Update(AppointmentDTO dto)
        {
            var ex = MapperConfig.GetMapper().Map<Appointment>(dto);
            return factory.GetRepo<Appointment>().Update(ex);
        }

        public bool Delete(int id)
        {
            return factory.GetRepo<Appointment>().Delete(id);
        }



        // features via feature repo
        public bool ChangeStatus(int appointmentId, string status)
        {
            var success = factory.AppointmentFeature().ChangeStatus(appointmentId, status);

            if (!success) return false;

            // Send email only if canceled
            if (status == "Canceled")
            {
                var ap = factory.AppointmentFeature().GetWithRelations(appointmentId);

                if (ap != null && ap.Patient != null && ap.Doctor != null)
                {
                    string body =
                        $"Hello {ap.Patient.FirstName},\n\n" +
                        $"Your appointment with Dr. {ap.Doctor.FirstName} {ap.Doctor.LastName} " +
                        $"scheduled on {ap.AppointmentDate:dddd, MMM dd yyyy hh:mm tt} " +
                        $"has been CANCELED due to unavoidable circumstances.\n\n" +
                        $"Sorry for the inconvenience.";

                    EmailHelper.SendEmail(ap.Patient.Email, "Appointment Canceled", body);
                }
            }

            return true;
        }



        public List<AppointmentDTO> GetByDoctor(int doctorId)
        {
            var data = factory.AppointmentFeature().GetByDoctor(doctorId);
            return data.Select(a =>MapperConfig.GetMapper().Map<AppointmentDTO>(a)).ToList();
        }

        public List<AppointmentDTO> GetByPatient(int patientId)
        {
            var data = factory.AppointmentFeature().GetByPatient(patientId);
            return data.Select(a =>MapperConfig.GetMapper().Map<AppointmentDTO>(a)).ToList();
        }
    }
}
