using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetAllDoctors();
        Task<Doctor> GetDoctorByName(string name);
        Task AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(string name, string specializedin);
        Task<int> GetTotalDoctorsCount();
        Task<IEnumerable<Doctor>> GetAllPaginatedDoctors(int pageNumber, int pageSize);

        Task<IEnumerable<Doctor>> SearchDoctor(string name);
    }
}
