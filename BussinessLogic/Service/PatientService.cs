using BussinessLogic.DTOs;
using DataAccess.Entities;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patient;

        public PatientService(IPatientRepository patient)
        {
            _patient = patient;
        }

        public async Task<IEnumerable<GetPatientDto>> GetAllPatient()
        {
           var PatientFromRepo = await _patient.GetAllPatient();
            var Patientdto = PatientFromRepo.Select(cat => new GetPatientDto()
            {
                Name = cat.Name,
                Email = cat.Email,  
                Phone = cat.Phone,
                Gender = cat.Gender
            });
            return Patientdto;
        }


        public async Task<GetPatientDto> GetPatientOnlyByName(string name)
        {
            var patientfromrepo =await _patient.GetPatientByName(name);
            var PatientDto = new GetPatientDto()
            {
                Name = patientfromrepo.Name,
                Phone = patientfromrepo.Phone,
                Email = patientfromrepo.Email,
                Gender = patientfromrepo.Gender
            };
            return PatientDto;
        }


        public async Task AddPatient(AddPatientDto dto)
        {
            var patienttorepo = new Patient()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Gender = dto.Gender,
            };

            await _patient.AddPatient(patienttorepo);
        }


        public async Task EditPatient(AddPatientDto dto)
        {
            var patienttorepo = new Patient()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Email = dto.Email,
                Gender = dto.Gender,
            };
            await _patient.EditPatient(patienttorepo);
        }

        public async Task DeletePatient(DeletePatientDto dto)
        {
           await _patient.DeletePatient(dto.Name , dto.Phone); // i am not sure in this way!!
        }


    }
}
