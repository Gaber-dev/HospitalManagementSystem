using BussinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IPatientService
    {
        Task<IEnumerable<GetPatientDto>> GetAllPatient();
        Task<GetPatientDto> GetPatientOnlyByName(string name);
        Task AddPatient(AddPatientDto dto);
        Task EditPatient(AddPatientDto dto);
        Task DeletePatient(DeletePatientDto dto);
    }
}
