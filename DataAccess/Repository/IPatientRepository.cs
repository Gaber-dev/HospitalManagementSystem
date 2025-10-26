using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatient();
        Task<Patient> GetPatientByName(string Name);
        Task AddPatient(Patient patient);
        Task EditPatient(Patient patient);
        Task DeletePatient(string name, string phone); 
    }
}
