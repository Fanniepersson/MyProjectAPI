using Microsoft.EntityFrameworkCore;
using MyProjectAPI.API.Data;
using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Services
{
    public class EmployeeRepository : IEmployee
    {
        private AppDbContext _appContext;

        public EmployeeRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        //LÄGGA TILL ANSTÄLLDA
        public async Task<Employee> Add(Employee newEntity)
        {
            var result = await _appContext.Employees.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        //TA BORT ANSTÄLLD
        public async Task<Employee> Delete(int id)
        {
            var result = await _appContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
            if (result != null)
            {
                _appContext.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;

            }
            return null;
        }
        //HÄMTAR ALLA ANSTÄLLDA
        public IEnumerable<Employee> GetAll()
        {
            return _appContext.Employees;
            
        }

        //HÄMTAR SPECIFIK ANSTÄLLD & DESS TIDSRAPPORTER
        public async Task<Employee> GetEmployeeTimReport(int id)
        {
            return await _appContext.Employees.Include(e => e.TimReport).FirstOrDefaultAsync(e => e.EmployeeID == id);
            
        }

        public async Task<Employee> GetSingle(int id)
        {
            return await _appContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == id);
        }


        //UPPDATERA ANSTÄLLD
        public async Task<Employee> Update(Employee entity)
        {
            var result = await _appContext.Employees.FirstOrDefaultAsync(e => e.EmployeeID == entity.EmployeeID);
            if (result != null)
            {
                result.FName = entity.FName;
                result.LName = entity.LName;
                result.Email = entity.Email;
                result.ProjectID = entity.ProjectID;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
