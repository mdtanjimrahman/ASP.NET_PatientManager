using BLL.DTOs;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Services
{
    public class ReportService
    {
        DataAccessFactory factory;

        public ReportService(DataAccessFactory factory)
        {
            this.factory = factory;
        }

        public SystemSummaryDTO GetSystemSummary()
        {
            var data = factory.SummaryReport().GetSystemSummary();

            return new SystemSummaryDTO
            {
                TotalPatients = (int)data.GetType().GetProperty("TotalPatients").GetValue(data),
                TotalDoctors = (int)data.GetType().GetProperty("TotalDoctors").GetValue(data),
                TotalAppointments = (int)data.GetType().GetProperty("TotalAppointments").GetValue(data)
            };
        }

        public List<AppointmentStatusSummaryDTO> GetAppointmentStatusSummary()
        {
            return factory.SummaryReport()
                          .GetAppointmentStatusSummary()
                          .Select(x => new AppointmentStatusSummaryDTO
                          {
                              Status = (string)x.GetType().GetProperty("Status").GetValue(x),
                              Total = (int)x.GetType().GetProperty("Total").GetValue(x)
                          }).ToList();
        }
    }
}
