using DataAccess.Context;
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
    public class ReservationRepository : GenericRepo<Reservation>, IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Reservation> GetReservationByDateandpname(DateTime time , string patientname)
        {
           var res = await _context.Reservation.Include(r => r.Patient).Include(r => r.Doctor).FirstOrDefaultAsync(r => r.ReservationDate == time && r.Patient.Name == patientname);
            return res;
        }


        public async Task UpdateReservation(Reservation updatedres)
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservation(DateTime date , string patientname)
        {
           var res = await _context.Reservation.FirstOrDefaultAsync(r => r.ReservationDate == date && r.Patient.Name == patientname);
            if(res == null)
            {
                throw new Exception("No Reservation at that time");
            }
            else
            {
                _context.Reservation.Remove(res);
                await _context.SaveChangesAsync();
            }
        }


    }
}
