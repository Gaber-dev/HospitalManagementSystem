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


        public async Task<GetReservationDto> GetResBypatnameanddate(DateTime date , string patientname)
        {
            var reservationfromrepo = await _repo.GetReservationByDateandpname(date , patientname);

            if (reservationfromrepo == null)
                throw new Exception($"No reservation found for {patientname} on {date.ToShortDateString()}");

            if (reservationfromrepo.Patient == null)
                throw new Exception("Reservation found but Patient navigation property is null. Make sure to include it in your repository.");

            if (reservationfromrepo.Doctor == null)
                throw new Exception("Reservation found but Doctor navigation property is null. Make sure to include it in your repository.");


            var restocontroller = new GetReservationDto()
            {
                ReservationDate = reservationfromrepo.ReservationDate,
                Status = reservationfromrepo.Status,
                PatientName = reservationfromrepo.Patient.Name,
                DoctorName = reservationfromrepo.Doctor.Name
            };
            return restocontroller;
        }

        public async Task UpdateReservation(UpdateReservationDto dto)
        {
            var reservation = await _repo.GetReservationByDateandpname(dto.ReservationDate.Value, dto.PatientName);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            reservation.ReservationDate = dto.ReservationDate.Value;

            if (!string.IsNullOrEmpty(dto.Status) && dto.Status.ToLower() != "string")
                reservation.Status = dto.Status;

            if (!string.IsNullOrEmpty(dto.DoctorName) && dto.DoctorName.ToLower() != "string")
                reservation.Doctor.Name = dto.DoctorName;
            await _repo.UpdateReservation(reservation);
        }


        

    }
}
