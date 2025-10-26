using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Patient>> GetAllPatient()
        {
           return await _context.Patient.ToListAsync();
        }


        public async Task<Patient> GetPatientByName(string name)
        {
          var Patient =  await _context.Patient.FirstAsync(p => p.Name == name);
            return Patient;
        }

        public async Task AddPatient(Patient patient)
        {
            await _context.Patient.AddAsync(patient);
            await _context.SaveChangesAsync();
        }


        public async Task EditPatient(Patient patient)
        {
            await _context.SaveChangesAsync();
        }


        public async Task DeletePatient(string name , string phone)
        {
            var PatientFromDb = await _context.Patient.FirstOrDefaultAsync(p => p.Name == name && p.Phone == phone);


           _context.Remove(PatientFromDb);
           await _context.SaveChangesAsync();
        }

        
    }
}
