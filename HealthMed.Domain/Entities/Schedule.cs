using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Entities
{
    public class Schedule : Entity
    {
        public DateTime Date { get; set; }
        public long DoctorId { get; set; }
        public Person Doctor { get; set; }
        public bool Available { get; set; } = true;
    }
}
