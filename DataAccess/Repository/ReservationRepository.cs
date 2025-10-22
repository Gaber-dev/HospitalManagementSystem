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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
          return await  _context.Reservation.Include(d => d.Doctor)
                .Include(p => p.Patient).ToListAsync();
        }

        public async Task AddReservation(Reservation reservation)
        {
            await _context.Reservation.AddAsync(reservation);
            await _context.SaveChangesAsync();
        }

    }
}
