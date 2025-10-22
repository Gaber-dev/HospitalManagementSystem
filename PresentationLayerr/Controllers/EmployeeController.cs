using BussinessLogic.DTOs;
using BussinessLogic.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<getEmployeeDto>> GetAllEmployee()
        {
           return Ok( await _service.GetAllEmployee());
        }



        [HttpGet("Name")]
        public async Task<ActionResult<getEmployeeDto>> GetEmployeeByName(string name)
        {
            var res = await _service.GetEmployeeByName(name);
            return Ok(res);
        }


        [HttpPost]
        public async Task<ActionResult<AddEmployeeDto>> AddEmployee(AddEmployeeDto dto)
        {
            await _service.AddEmployee(dto);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(UpdateEmployeeDto dto)
        {
            await _service.UpdateEmployee(dto);
            return NoContent();
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteEmployee(string name)
        {
            await _service.DeleteEmployee(name);
            return NoContent();
        }
    }
}
