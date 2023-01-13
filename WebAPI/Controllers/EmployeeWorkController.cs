using Business.Abstract;
using Entities.Concrete;
using Entities.DtoS;
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
    public class EmployeeWorkController : ControllerBase
    {
        IEmployeeWorkService _employeeWorkService;
        public EmployeeWorkController(IEmployeeWorkService employeeWorkService)
        {
            _employeeWorkService = employeeWorkService;
        }

        [HttpPost("add")]
        public IActionResult Add(EmployeeWork employeeWork)
        {
            var result = _employeeWorkService.Add(employeeWork);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _employeeWorkService.GetAll();

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
