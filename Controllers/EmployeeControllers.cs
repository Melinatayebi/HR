using Microsoft.AspNetCore.Mvc;
using HR.Entities;
using HR.Services;
using HR.ViewModels.Employee;

namespace HR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService _employeesService;
        public EmployeeController(IEmployeeService employeesService)
        {
            _employeesService = employeesService;
        }

        [HttpGet("Get")]
        public IEnumerable<EmpoloyeeViewModel> Get()
        {
            return _employeesService.GetList();
        }

        [HttpGet("Get Employee & Department")]
        public IEnumerable<EmpoloyeeViewModel> GetExtra()
        {
            return _employeesService.GetListExtra();
        }

        [HttpPost("Post")]
        public IActionResult CreateEmployee(CreateEmployeeRequest employe)
        {
           
                var Response = _employeesService.Create(employe);

                return Ok(Response);
        }


        [HttpPost("Post Find Employee By NationalCode")]
        public IActionResult FindEmployee(string nationalCode)
        {

            var Response = _employeesService.GetViewModelByNationalCode(nationalCode);

            return Ok(Response);
        }

        [HttpDelete("Delete")]
        public IActionResult RemoveEmployee(RemoveEmployeeRequest employee)
        {
            try
            {
              var response = _employeesService.Remove(employee);
                return Ok(response);
            }
            catch (Exception)
            { 
                return BadRequest();
            }
        }
    }
}
