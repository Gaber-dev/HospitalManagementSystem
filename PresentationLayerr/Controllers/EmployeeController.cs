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


        [HttpPost]
        public async Task<ActionResult<AddEmployeeDto>> AddEmployee(AddEmployeeDto dto)
        {
            await _service.AddEmployee(dto);
            return NoContent();
        }
    }
}
