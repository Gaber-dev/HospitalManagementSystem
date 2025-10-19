using BussinessLogic.DTOs;
using BussinessLogic.Service;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IClinicService _clinic;
        public ClinicController(IClinicService clinic)
        {
             _clinic = clinic;   
        }



        [HttpGet]
        public async Task<ActionResult<GetClinicDto>> GetAllClinics()
        {
            return Ok(await _clinic.GetAllClinics());
        }

        [HttpGet("Name")]
        public async Task<ActionResult<GetClinicDto>> GetClinicByName(string name)
        {
            return Ok(await _clinic.GetClinicOnlyByName(name));
        }


        [HttpPost]
        public async Task<ActionResult> AddClinic(AddClinicDto clinicdto)
        {
            await _clinic.AddClinic(clinicdto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditClinic(AddClinicDto clinicdto)
        {
            await _clinic.EditClinic(clinicdto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(DeleteClinicDto dto)
        {
            await _clinic.DeleteClinic(dto);
            return Ok();
        }

    }
}
