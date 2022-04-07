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
    public class EmployeesController : ControllerBase
    {
        private IEmployee _employee;

        public EmployeesController(IEmployee employee)
        {
            _employee = employee;
        }


        //HÄMTA ALLA ANSTÄLLDA
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            try
            {
                return Ok(_employee.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database");
                
            }
          
        }

        //TA BORT ANSTÄLLD
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var EmployeeToDelete = await _employee.GetSingle(id);
                if (EmployeeToDelete == null)
                {
                    return NotFound($"Employee with ID {id} could not be found");

                }
                return await _employee.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from database");
                
            }
        }

        //UPPDATERA ANSTÄLLD
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee (int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return BadRequest("Employee could not be found");
                }
                var EmployeeToUpdate = await _employee.GetSingle(id);
                if (EmployeeToUpdate == null)
                {
                    return NotFound($"Employee with id {id} could not be found");

                }
                return await _employee.Update(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update data");
                
            }
        }

        //LÄGGA TILL NY ANSTÄLLD
        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee NewEntity)
        {
            try
            {
                return await _employee.Add(NewEntity);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add data");
                
            }
        }

        //HÄMTA SPECIFIK ANSTÄLLD OCH DESS TIDRAPPORTER
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetSingleEmployee(int id)
        {
            try
            {
                var result = await _employee.GetEmployeeTimReport(id);
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
