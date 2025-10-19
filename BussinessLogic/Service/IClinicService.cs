using BussinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IClinicService
    {
        Task<IEnumerable<GetClinicDto>> GetAllClinics();
        Task<GetClinicDto> GetClinicOnlyByName(string name);
        Task AddClinic(AddClinicDto dto);
        Task EditClinic(AddClinicDto dto);
        Task DeleteClinic(DeleteClinicDto dto);
    }
}
