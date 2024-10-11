using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTOs
{
    public class CreateScheduleDTO
    {
        public DateTime Date { get; set; }
        public long DoctorId { get; set; }
    }
}
