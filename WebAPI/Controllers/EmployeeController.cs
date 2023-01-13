using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();

            if (result.Suscces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetEmployeeById(id);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Employee employee)
        {
            var result = _employeeService.Add(employee);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Employee employee)
        {
            var result = _employeeService.Update(employee);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Employee employee)
        {
            var result = _employeeService.Delete(employee);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
