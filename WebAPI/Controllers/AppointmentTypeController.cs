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
    public class AppointmentTypeController : ControllerBase
    {
        IAppointmentTypeService _appointmentTypeService;

        public AppointmentTypeController(IAppointmentTypeService appointmentTypeService)
        {
            _appointmentTypeService = appointmentTypeService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _appointmentTypeService.GetAll();

            if (result.Suscces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(AppointmentType appointmentType)
        {
            var result = _appointmentTypeService.Add(appointmentType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AppointmentType appointmentType)
        {
            var result = _appointmentTypeService.Update(appointmentType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AppointmentType appointmentType)
        {
            var result = _appointmentTypeService.Delete(appointmentType);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
