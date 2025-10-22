using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTOs
{
    public class GetReservationDto
    {
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
