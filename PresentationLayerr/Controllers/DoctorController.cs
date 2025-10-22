using BussinessLogic.DTOs;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<GetDoctorDto>> GetDoctorsData()
        {
            return Ok(await _service.GetAllDoctors());
        }

        [HttpGet("Name")]
        public async Task<ActionResult<GetDoctorDto>> GetDoctorbyName(string name)
        {
            return Ok(await _service.GetDoctorByName(name));
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor(AddDoctorDto dto)
        {
            await _service.AddDoctor(dto);
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> UpdateDoctor(UpdateDoctorDto dto)
        {
            await _service.UpdateDoctor(dto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDoctor(string name , string specialiedin)
        {
           await _service.DeleteDoctor(name, specialiedin);
            return Ok();
        }

    }
}
