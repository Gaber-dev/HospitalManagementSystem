using BussinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Service
{
    public interface IReservationService
    {
        Task<IEnumerable<GetReservationDto>> GetAllReservation();
        Task AddReservation(AddReservationDto dto);
    }
}
