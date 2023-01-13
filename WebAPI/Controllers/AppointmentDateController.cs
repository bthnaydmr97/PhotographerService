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
    public class AppointmentDateController : ControllerBase
    {
        IAppointmentDateService _appointmentDateService;
        public AppointmentDateController(IAppointmentDateService appointmentDateService)
        {
            _appointmentDateService = appointmentDateService;
        }

        //[HttpGet("getall")]
        //public IActionResult GetAll()
        //{
        //    var result = _appointmentDateService.GetAll();

        //    if (result.Suscces)
        //    {
        //        return Ok(result.Data);
        //    }

        //    return BadRequest(result.Message);
        //}

        //[HttpPost("getbyid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _appointmentDateService.GetAppointmentById(id);

        //    if (result.Suscces)
        //    {
        //        return Ok(result);
        //    }

        //    return BadRequest(result);
        //}

        [HttpPost("add")]
        public IActionResult Add(AppoinmentDate appointmentDate)
        {
            var result = _appointmentDateService.Add(appointmentDate);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AppoinmentDate appointmentDate)
        {
            var result = _appointmentDateService.Update(appointmentDate);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AppoinmentDate appointmentDate)
        {
            var result = _appointmentDateService.Delete(appointmentDate);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
