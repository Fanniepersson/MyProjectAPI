using Microsoft.EntityFrameworkCore;
using MyProjectAPI.API.Data;
using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Services
{
    public class ProjectRepoitory : IProject
    {
        private AppDbContext _appContext;

        public ProjectRepoitory(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        //LÄGGA TILL PROJEKT
        public async Task<Project> Add(Project NewEntity)
        {
            var result = await _appContext.Projects.AddAsync(NewEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        //TA BORT PROJEKT
        public async Task<Project> Delete(int id)
        {
            var result = await _appContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == id);
            if (result != null)
            {
                _appContext.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;

            }
            return null;
        }

        //LISTA MED ALLA SOM JOBBAR MED ETT SPECIELLT PROJEKT
        public async Task<Project> GetSingle(int id)
        {
            return await _appContext.Projects.Include(p => p.Employee).FirstOrDefaultAsync(p => p.ProjectID == id);
            
        }

        //UPPDATERA PROJEKT
        public async Task<Project> Update(Project entity)
        {
            var result = await _appContext.Projects.FirstOrDefaultAsync(p => p.ProjectID == entity.ProjectID);
            if (result != null)
            {
                result.ProjectName = entity.ProjectName;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
        
        //HÄMTA ALLA PROJEKT
        public IEnumerable<Project> GetAll()
        {
            return _appContext.Projects;
        }
    }
}
