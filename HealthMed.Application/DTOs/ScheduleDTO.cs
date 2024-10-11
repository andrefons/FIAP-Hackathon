using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class ScheduleDTO
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long DoctorId { get; set; }
    }
}
