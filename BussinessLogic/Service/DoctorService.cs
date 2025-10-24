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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;
        private readonly IClinicRepository _clinic;
        public DoctorService(IDoctorRepository repo , IClinicRepository clinic)
        {
            _repo = repo;
            _clinic = clinic;
        }

        public async Task<IEnumerable<GetDoctorDto>> GetAllDoctors()
        {
            var Doctors = await _repo.GetAllDoctors();
           var doctocontroller =  Doctors.Select(doc => new GetDoctorDto
            {
                Name = doc.Name,
                Email = doc.Email,
                Phone = doc.Phone,
                SpecialIn = doc.SpecialIn,
                ClinicName = doc.Clinic.Name
            });
            return doctocontroller;
        }


        public async Task<GetDoctorDto> GetDoctorByName(string name)
        {
            
            var docfromrepo = await _repo.GetDoctorByName(name); 


            var emptocontroller = new GetDoctorDto()
            {
                Name = docfromrepo.Name,
                Phone = docfromrepo.Phone,
                Email = docfromrepo.Email,
                SpecialIn = docfromrepo.SpecialIn,
                ClinicName = docfromrepo.Clinic.Name
            };
            return emptocontroller;
        }



        public async Task AddDoctor(AddDoctorDto dto)
        {
            var clinicdetails = await _clinic.GetClinicByName(dto.ClinicName);

            var doctorepo = new Doctor()
            {
                Name = dto.Name,
                Email = dto.Email,

                SpecialIn = dto.SpecialIn,
                Phone = dto.Phone,
                   ClinicId = clinicdetails.ID
            };
            await _repo.AddDoctor(doctorepo);
        }


        public async Task UpdateDoctor(UpdateDoctorDto dto)
        {

            var existingDoctor = await _repo.GetDoctorByName(dto.Name);
            if (existingDoctor == null)
            {
                throw new Exception("Doctor not Found");
            }


            if (!string.IsNullOrEmpty(dto.Name) && dto.Name.ToLower() != "string")
                existingDoctor.Name = dto.Name;


            if (!string.IsNullOrEmpty(dto.Phone) && dto.Phone.ToLower() != "string")
                existingDoctor.Phone = dto.Phone;

            if (!string.IsNullOrEmpty(dto.Email) && dto.Email.ToLower() != "string")
                existingDoctor.Email = dto.Email;

            if (!string.IsNullOrEmpty(dto.SpecialIn) && dto.SpecialIn.ToLower() != "string")
                existingDoctor.SpecialIn = dto.SpecialIn;

            if (!string.IsNullOrEmpty(dto.ClinicName) && dto.ClinicName.ToLower() != "string")
            {
                var existingClinic = await _clinic.GetClinicByName(dto.ClinicName);
                if (existingClinic != null)
                    existingDoctor.ClinicId = existingClinic.ID;

            }

            await _repo.UpdateDoctor(existingDoctor);
        }



        public async Task DeleteDoctor(string name, string specializedin)
        {
            await _repo.DeleteDoctor(name , specializedin);
        }

        public async Task<GetDoctorPaginatedDto> Getpaginateddoctors(int pageNumber , int pageSize)
        {
            var totalcount =  await _repo.GetTotalDoctorsCount();
            var doctors =await _repo.GetAllPaginatedDoctors(pageNumber, pageSize);

            var doctordto = doctors.Select(d => new GetDoctorDto
        {
            Name = d.Name,
            Phone = d.Phone,
            Email = d.Email,
            SpecialIn = d.SpecialIn,
            ClinicName = d.Clinic.Name
         });


         return new GetDoctorPaginatedDto
         {
            Items = doctordto,
            Totalcount = totalcount,
            pageSize = pageSize,
            pageNumber = pageNumber
         };
   }


   public async Task<IEnumerable<GetDoctorDto>> SearchAboutDoctor(string name)
   {
            var resfromrepo = await _repo.SearchDoctor(name);

            var restocontroller = resfromrepo.Select(d => new GetDoctorDto
            {
                Name = d.Name,
                Phone = d.Phone,
                Email = d.Email,
                SpecialIn = d.SpecialIn,
                ClinicName = d.Clinic.Name
            });
    return restocontroller;
}



    }
}


