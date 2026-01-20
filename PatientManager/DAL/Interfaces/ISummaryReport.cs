using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ISummaryReport
    {
        // System totals
        object GetSystemSummary();

        // Appointment status summary
        List<object> GetAppointmentStatusSummary();
    }
}
