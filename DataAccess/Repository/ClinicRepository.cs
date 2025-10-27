using DataAccess.Context;
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
    public class ClinicRepository : GenericRepo<Clinic> , IClinicRepository
    {
        private readonly ApplicationDbContext _context;

        public ClinicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        


        public async Task<Clinic?> GetClinicByName(string name)
        {
            var Clinic = await _context.Clinic.SingleOrDefaultAsync(c => c.Name == name);
            return Clinic;
        }

       


        public async Task EditClinic(Clinic clinic)
        {
            var ClinicFromDb = await _context.Clinic.FirstOrDefaultAsync(c => c.Name == clinic.Name);
            ClinicFromDb.Phone = clinic.Phone;
            ClinicFromDb.Name = clinic.Name;
            ClinicFromDb.Address = clinic.Address;
            await _context.SaveChangesAsync();
        }


        public async Task DeleteClinic(string name , string address)
        {
            var ClinicFromDb = await _context.Clinic.FirstOrDefaultAsync(p => p.Name == name && p.Address == address);
            _context.Remove(ClinicFromDb);
            await _context.SaveChangesAsync();
        }
    }
}
