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
    public class WorkingTypeController : ControllerBase
    {
        IWorkingTypeService _workingTypeService;

        public WorkingTypeController(IWorkingTypeService workingTypeService)
        {
            _workingTypeService = workingTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _workingTypeService.GetAll();

            if (result.Suscces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(WorkingType workingType)
        {
            var result = _workingTypeService.Add(workingType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(WorkingType workingType)
        {
            var result = _workingTypeService.Update(workingType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(WorkingType workingType)
        {
            var result = _workingTypeService.Delete(workingType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
