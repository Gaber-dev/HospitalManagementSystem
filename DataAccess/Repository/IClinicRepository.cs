using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IClinicRepository
    {
        Task<IEnumerable<Clinic>> GetAllClinics();
        Task<Clinic> GetClinicByName(string name);
        Task AddClinic(Clinic clinic);
        Task EditClinic(Clinic clinic);
        Task DeleteClinic(string name , string address);
    }
}
