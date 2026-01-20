using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs
{
    public class SystemSummaryDTO
    {
        public int TotalPatients { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalAppointments { get; set; }
    }
}
