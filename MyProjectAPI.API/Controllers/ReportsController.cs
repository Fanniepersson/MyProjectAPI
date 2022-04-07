using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProjectAPI.API.Services;
using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private ITimReport _timReport;

        public ReportsController(ITimReport timReport)
        {
            _timReport = timReport;
        }


        //HÄMTA ALLA TIDRAPPORTER
        [HttpGet]
        public IActionResult GetAllTimReports()
        {
            try
            {
                return Ok(_timReport.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database");
            }
            
        }

        //LÄGGA TILL NY TIMRAPPORT
        [HttpPost]
        public async Task<ActionResult<TimReport>> AddTimReport(TimReport newEntity)
        {
            try
            {
                return await _timReport.Add(newEntity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add data to database");
               
            }
        }

        //TA BORT TIMRAPPORT
        [HttpDelete("{id}")]
        public async Task<ActionResult<TimReport>> DeleteTimReport(int id)
        {
            try
            {
                var TimRepToDelete = await _timReport.GetSingle(id);
                if (TimRepToDelete == null)
                {
                    return NotFound("Timreport could not be found");
                }
                return await _timReport.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from database");
                
            }
        }

        //UPPDATERA TIMRAPPORT
        [HttpPut("{id}")]
        public async Task<ActionResult<TimReport>> UpdateTimReport(int id, TimReport timReport)
        {
            try
            {
                if (id != timReport.ReportID)
                {
                    return BadRequest("TimReport could not be found");
                }
                var TimReportToUpdate = await _timReport.GetSingle(id);
                if (TimReportToUpdate == null)
                {
                    return NotFound($"Timreport with id {id} could not be found");
                }
                return await _timReport.Update(timReport);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update data");
            }
        }

        //HÄMTA SPECIFIK TIMRAPPORT FÖR SPECIFIK ANSTÄLLD
        [HttpGet("{id:int}/{choosenWeek}")]
        public async Task<ActionResult<TimReport>> GetSpecifikEmployee(int id, int choosenWeek)
        {
            try
            {
                var result = await _timReport.SearchTimReport(id, choosenWeek);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to get data from database");

            }
        }
    }
}
