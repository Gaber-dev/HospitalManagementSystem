using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservation();
        Task AddReservation(Reservation reservation);
        Task<Reservation> GetReservationByDateandpname(DateTime time, string patientname);
        Task UpdateReservation(Reservation updatedres);
        Task DeleteReservation(DateTime date, string patientname);
    }
}
