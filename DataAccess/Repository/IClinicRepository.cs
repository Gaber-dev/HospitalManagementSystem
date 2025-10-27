using DataAccess.Entities;
using DataAccess.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IClinicRepository : IGenericRepository<Clinic>
    {
        Task<Clinic?> GetClinicByName(string name);
        Task EditClinic(Clinic clinic);
        Task DeleteClinic(string name , string address);
    }
}
