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
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repo;
        private readonly IPatientRepository _patientrepo;
        private readonly IDoctorRepository _doctorrepo;
        public ReservationService(IReservationRepository repo , IPatientRepository patientrepo , IDoctorRepository doctorrepo)
        {
            _repo = repo;
            _patientrepo = patientrepo;
            _doctorrepo = doctorrepo;
        }

        public async Task<IEnumerable<GetReservationDto>> GetAllReservation()
        {
            var reservationfromrepo = await _repo.GetAllReservation();

            var restocontroller = reservationfromrepo.Select(res => new GetReservationDto
            {
                ReservationDate = res.ReservationDate,
                Status = res.Status,
                PatientName = res.Patient.Name,
                DoctorName = res.Doctor.Name
            });
            return restocontroller;
        }


        public async Task AddReservation(AddReservationDto dto)
        {
            var patient = await _patientrepo.GetPatientByName(dto.PatientName);
            if (patient == null)
                throw new Exception($"Patient '{dto.PatientName}' not found.");

            var doctor = await _doctorrepo.GetDoctorByName(dto.DoctorName);
            if (doctor == null)
                throw new Exception($"Doctor '{dto.DoctorName}' not found.");

            var reservation = new Reservation()
            {
                ReservationDate = dto.ReservationDate,
                Status = "Pending",
                PatientId = patient.ID,
                DoctorId = doctor.ID
            };

            await _repo.AddReservation(reservation);
        }
    }
}
