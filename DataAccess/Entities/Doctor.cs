using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string SpecialIn { get; set; }

        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }

        public ICollection<Reservation> Reservation { get; set; } = new HashSet<Reservation>();

    }
}
