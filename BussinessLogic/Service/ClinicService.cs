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
    public class ClinicService : IClinicService
    {
        private readonly IClinicRepository _clinic;

        public ClinicService(IClinicRepository clinic)
        {
            _clinic = clinic;
        }

        public async Task<IEnumerable<GetClinicDto>> GetAllClinics()
        {
            var ClinicFromRepo = await _clinic.GetAllClinics();
            var Clinicdto = ClinicFromRepo.Select(cat => new GetClinicDto()
            {
                Name = cat.Name,
                Phone = cat.Phone,
                Address = cat.Address,
            });
            return Clinicdto;
        }


        public async Task<GetClinicDto> GetClinicOnlyByName(string name)
        {
            var Clinicfromrepo = await _clinic.GetClinicByName(name);
            var ClinicDto = new GetClinicDto()
            {
                Name = Clinicfromrepo.Name,
                Phone = Clinicfromrepo.Phone,
                Address = Clinicfromrepo.Address
            };
            return ClinicDto;
        }


        public async Task AddClinic(AddClinicDto dto)
        {
            var Clinictorepo = new Clinic()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Address= dto.Address
            };

            await _clinic.AddClinic(Clinictorepo);
        }


        public async Task EditClinic(AddClinicDto dto)
        {
            var Clinictorepo = new Clinic()
            {
                Name = dto.Name,
                Phone = dto.Phone,
                Address = dto.Address,
            };
            await _clinic.EditClinic(Clinictorepo);
        }

        public async Task DeleteClinic(DeleteClinicDto dto)
        {
            await _clinic.DeleteClinic(dto.Name, dto.Address); 
        }
    }
}
