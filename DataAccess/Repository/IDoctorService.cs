using BussinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IDoctorService
    {
        Task<IEnumerable<GetDoctorDto>> GetAllDoctors();
        Task<GetDoctorDto> GetDoctorByName(string name);
        Task AddDoctor(AddDoctorDto dto);
        Task UpdateDoctor(UpdateDoctorDto dto);
        Task DeleteDoctor(string name, string specializedin);
    }
}
