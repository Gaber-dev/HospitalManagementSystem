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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
           return await _context.Employee.Include(e => e.Clinic).ToListAsync( );
        }

        public async Task<Employee> GetEmployeeByName(string name)
        {
           return await _context.Employee.Include(e=>e.Clinic).SingleOrDefaultAsync(e=>e.Name == name);
        }


        public async Task AddEmployee(Employee employee)
        {
           await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployee(string name)
        {
           var empfromDb =  await _context.Employee.FirstOrDefaultAsync(e => e.Name == name);
            if(empfromDb != null)
            {
                _context.Employee.Remove(empfromDb);
                await _context.SaveChangesAsync();
            }
        }
    }
}
