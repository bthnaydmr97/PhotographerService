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
    public class AppointmentController : ControllerBase
    {
        IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _appointmentService.GetAll();

            if (result.Suscces)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _appointmentService.GetAppointmentById(id);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Appointment appointment)
        {
            var result = _appointmentService.Add(appointment);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Appointment appointment)
        {
            var result = _appointmentService.Update(appointment);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Appointment appointment)
        {
            var result = _appointmentService.Delete(appointment);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
