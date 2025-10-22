using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTOs
{
    public class UpdateEmployeeDto
    {
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Phone { get; set; }
        public string? ClinicName { get; set; }
    }
}
