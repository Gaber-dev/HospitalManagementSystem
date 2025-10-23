using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.DTOs
{
    public class GetDoctorPaginatedDto
    {
        public IEnumerable<GetDoctorDto> Items { get; set; }
        public int Totalcount { get; set; }

        public int pageNumber { get; set; }

        public int pageSize { get; set; }
    }
}
