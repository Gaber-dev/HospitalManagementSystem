using BussinessLogic.DTOs;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<GetPatientDto>> GetAllPatients()
        {
           return Ok( await _service.GetAllPatient());
        }

        [HttpGet("Name")]
        public async Task<ActionResult<GetPatientDto>> GetPatientByName(string name)
        {
            return Ok(await _service.GetPatientOnlyByName(name));
        }


        [HttpPost]
        public async Task<ActionResult> AddPatient(AddPatientDto patientDto)
        {
            await _service.AddPatient(patientDto);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> EditPatient(AddPatientDto patientDto)
        {
            await _service.EditPatient(patientDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(DeletePatientDto dto)
        {
            await _service.DeletePatient(dto);
            return Ok();
        }

    }
}
