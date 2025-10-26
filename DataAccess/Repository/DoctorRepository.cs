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
    public class DoctorRepository : IDoctorRepository
    {

        private readonly ApplicationDbContext _context;

        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
           return await _context.Doctor.Include(c => c.Clinic).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByName(string name)
        {
            var docfromdb =  await _context.Doctor.Include(c => c.Clinic).FirstOrDefaultAsync(d => d.Name == name);
            if (docfromdb == null)
                throw new Exception("Doctor not found in Database");
            return docfromdb;
        }


        public async Task AddDoctor(Doctor doctor)
        {
            await _context.Doctor.AddAsync(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctor(string name, string specializedin)
        {
            var doctorFromDb =  await _context.Doctor.FirstOrDefaultAsync(d => d.Name == name && d.SpecialIn == specializedin);
            _context.Doctor.Remove(doctorFromDb);
            await _context.SaveChangesAsync();
        }



        // Apply pagination
        // total count of doctor records in Database all
        public async Task<int> GetTotalDoctorsCount()
        {
           var res = await _context.Doctor.CountAsync();
            return res;
        }

        public async Task<IEnumerable<Doctor>> GetAllPaginatedDoctors(int pageNumber , int pageSize) // 1,10
        {
          return await _context.Doctor
                .Include(c => c.Clinic)
                .Skip((pageNumber-1)*pageSize) // skip 0 items
                .Take(pageSize) // take next 10 items
                .ToListAsync();
        }


        public async Task<IEnumerable<Doctor>> SearchDoctor(string name)
        {
            if (string.IsNullOrEmpty(name) || name == "string")
            {
                throw new Exception("Please Enter Name first..");
            }
            else
            {

                return await _context.Doctor.Include(c => c.Clinic)
                      .Where(d => d.Name.Contains(name) ||
                             d.SpecialIn.Contains(name) ||
                             d.Clinic.Name.Contains(name))
                      .ToListAsync();

            }
        }



    }
}
