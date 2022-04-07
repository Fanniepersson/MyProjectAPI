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
    public class ProjectsController : ControllerBase
    {
        private IProject _project;

        public ProjectsController(IProject project)
        {
            _project = project;

        }

        //HÄMTA ALLA PROJEKT
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            try
            {
                return Ok(_project.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to retrieve data from database");
                
            }
        }


        //LÄGG TILL NYTT PROJEKT
        [HttpPost]
        public async Task<ActionResult<Project>> AddProject(Project NewEntity)
        {
            try
            {
                return await _project.Add(NewEntity);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to add data");

            }

        }
       
        //TA BORT PROJEKT
        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProject(int id)
        {
            try
            {
                var ProjectToDelete = await _project.GetSingle(id);
                if (ProjectToDelete == null)
                {
                    return NotFound($"Project with id {id} could not be found");
                }
                return await _project.Delete(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to delete data from database");
                
            }
        }

        //UPPDATERA PROJEKT
        [HttpPut("{id}")]
        public async Task<ActionResult<Project>> UpdateProject(int id, Project project)
        {
            try
            {
                if (id != project.ProjectID)
                {
                    return BadRequest("Project could not be found");
                }
                var ProjectToUpdate = await _project.GetSingle(id);
                if (ProjectToUpdate == null)
                {
                    return NotFound($"Project with id {id} could not be found");
                }
                return await _project.Update(project);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error to update data");

            }
        }

        //HÄMTA SPECIFIKT PROJEKT
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            try
            {
                var result = await _project.GetSingle(id);
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
