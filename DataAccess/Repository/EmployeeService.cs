using BussinessLogic.DTOs;
using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        private readonly IClinicRepository _clinic;
        public EmployeeService(IEmployeeRepository repo,IClinicRepository clinic)
        {
            _repo = repo;
            _clinic = clinic;
        }

        public async Task<IEnumerable<getEmployeeDto>> GetAllEmployee()
        {
            var employeesFromDb = await _repo.GetEmployee();
            var empdto = employeesFromDb.Select(emp => new getEmployeeDto
            {
                Name = emp.Name,
                Role = emp.Role,
                Phone = emp.Phone,
                ClinicName = emp.Clinic.Name
            });

            return empdto;
        }

        public async Task<getEmployeeDto> GetEmployeeByName(string name)
        {
            // ID , Name , Role , Phone , ClinicId
           var empfromrepo = await _repo.GetEmployeeByName(name); // Employee Type
           
            
            var emptocontroller = new getEmployeeDto()
            {
                Name = empfromrepo.Name,
                Role = empfromrepo.Role,
                Phone = empfromrepo.Phone,
                ClinicName = empfromrepo.Clinic.Name
            };
            return emptocontroller;
        }





        public async Task AddEmployee(AddEmployeeDto dto)
        {
            var clinicdetails = await _clinic.GetClinicByName(dto.ClinicName);

            var emptorepo = new Employee()
            {
                Name = dto.Name,
                Role = dto.Role,
                Phone = dto.Phone,
                ClinicId = clinicdetails.ID
            };
            await _repo.AddEmployee(emptorepo);
        }



        public async Task UpdateEmployee(UpdateEmployeeDto dto)
        {

            var existingEmployee =await  _repo.GetEmployeeByName(dto.Name);
            if(existingEmployee == null)
            {
                throw new Exception("Employee not Found");
            }

            //var existingClinic = await _clinic.GetClinicByName(dto.ClinicName);
            //if(existingClinic == null)
            //{
            //    throw new Exception("Clinic Not Found");
            //}



            if(!string.IsNullOrEmpty(dto.Phone) && dto.Phone.ToLower() != "string")
                existingEmployee.Phone = dto.Phone;

            if(!string.IsNullOrEmpty(dto.Role) && dto.Role.ToLower() != "string")
                existingEmployee.Role = dto.Role;

            if (!string.IsNullOrEmpty(dto.ClinicName) && dto.ClinicName.ToLower() != "string")
            {
                var existingClinic = await _clinic.GetClinicByName(dto.ClinicName);
                if(existingClinic != null)
                    existingEmployee.ClinicId = existingClinic.ID;
                
            }
            
           await _repo.UpdateEmployee(existingEmployee);
        }


        public async Task DeleteEmployee(string name)
        {
            await _repo.DeleteEmployee(name);
        }

    }
}
