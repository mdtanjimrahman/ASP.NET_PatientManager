using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Appointment, AppointmentDTO>().ReverseMap();

            cfg.CreateMap<Diagnosis, DiagnosisDTO>().ReverseMap();

            cfg.CreateMap<Doctor, DoctorDTO>().ReverseMap();

            cfg.CreateMap<Patient, PatientDTO>().ReverseMap();

            cfg.CreateMap<Prescription, PrescriptionDTO>().ReverseMap();

            cfg.CreateMap<Medication, MedicationDTO>().ReverseMap();
        });

        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
    }
}
