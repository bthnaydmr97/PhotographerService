using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] // api/DailyRecords
    [ApiController] // Attribute Bir class ile ilgili bilgi imzalama yöntemidir
    public class DailyRecordsController : ControllerBase
    {
        //IOC Container --Inversion of control(Bellekte ki bir yer. new PM() gibi. referanslar koyup kim ihtiyaç duyuyorsa buradan kullanabiliriz.)Singeleton pattern 
        //Eğer için de data tutmuyorsak bu yapıyı kullanabilriz. (Sepet gibi. eğer tutuluyoırsa singleton tek bir sefer newleyip her client onu kullandığı için sepetler karışır.)
        // Note: Eğer Sepet db den gelmiyorsa bu geçerlidir.
        IDailyRecordService _dailyRecordService;
        //ınterfaceler referans tutuculardır.

        public DailyRecordsController(IDailyRecordService dailyRecordService)
        {
            _dailyRecordService = dailyRecordService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _dailyRecordService.GetAll();

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _dailyRecordService.GetDailyRecordById(id);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(DailyRecord record)
        {
            var result = _dailyRecordService.Add(record);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DailyRecord record)
        {
            var result = _dailyRecordService.Update(record);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DailyRecord record)
        {
            var result = _dailyRecordService.Delete(record);

            if (result.Suscces)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
