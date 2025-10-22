using BussinessLogic.DTOs;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<getEmployeeDto>> GetAllEmployee();
        Task<getEmployeeDto> GetEmployeeByName(string name);
        Task AddEmployee(AddEmployeeDto dto);
        Task UpdateEmployee(UpdateEmployeeDto dto);
        Task DeleteEmployee(string name);
    }
}
