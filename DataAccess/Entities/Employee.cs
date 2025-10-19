using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
    }
}
