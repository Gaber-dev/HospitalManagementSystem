using BussinessLogic.DTOs;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<GetReservationDto>> GetAllReservation()
        {
            return Ok(await _service.GetAllReservation());
        }

        [HttpPost]
        public async Task<ActionResult> AddReservation(AddReservationDto dto)
        {
            await _service.AddReservation(dto);
            return Ok();
        }

        [HttpGet("Name and Date")]
        public async Task<ActionResult<GetReservationDto>> GetReserByDateandPName(DateTime time , string pname)
        {
            var res = await _service.GetResBypatnameanddate(time, pname);
            return Ok(res);
        }


       [HttpPut]
       public async Task<ActionResult> UpdateReservation(UpdateReservationDto dto)
       {
          await _service.UpdateReservation(dto);
          return Ok();
       } 
    }
}

