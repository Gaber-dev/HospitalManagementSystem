using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Clinic
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Doctor> Doctor { get; set; } = new HashSet<Doctor>();
        public ICollection<Employee> Employee { get; set; } = new HashSet<Employee>();


    }
}
