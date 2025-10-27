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
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetEmployeeByName(string name);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(string name);

    }
}
