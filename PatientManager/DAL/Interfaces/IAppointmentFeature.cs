using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IAppointmentFeature
    {
        List<Appointment> GetByDoctor(int doctorId);
        List<Appointment> GetByPatient(int patientId);
        bool ChangeStatus(int appointmentId, string status);
    }
}
