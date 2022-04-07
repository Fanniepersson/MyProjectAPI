using Microsoft.EntityFrameworkCore;
using MyProjectAPI.API.Data;
using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Services
{
    public class TimReportRepository : ITimReport
    {
        private AppDbContext _appContext;

        public TimReportRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        //LÄGGA TILL TIDSRAPPORT
        public async Task<TimReport> Add(TimReport newEntity)
        {
            var result = await _appContext.TimReports.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        //TA BORT TIDSRAPPORT
        public async Task<TimReport> Delete(int id)
        {
            var result = await _appContext.TimReports.FirstOrDefaultAsync(t => t.ReportID == id);
            if (result != null)
            {
                _appContext.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        //HÄMTA SPECIFIK TIDSRAPPORT
        public async Task<TimReport> GetSingle(int id)
        {
            return await _appContext.TimReports.FirstOrDefaultAsync(p => p.ReportID == id);
        }

        //UPPDATERA TIDSRAPPORT
        public async Task<TimReport> Update(TimReport entity)
        {
            var result = await _appContext.TimReports.FirstOrDefaultAsync(t => t.ReportID == entity.ReportID);
            if (result != null)
            {
                result.Week = entity.Week;
                result.wWorkingHours = entity.wWorkingHours;
                result.EmployeeID = entity.EmployeeID;

                await _appContext.SaveChangesAsync();
                return result;

            }
            return null;
        }

        //HÄMTA ALLA TIDSRAPPORTER
        public IEnumerable<TimReport> GetAll()
        {
            return _appContext.TimReports;
        }

        //FÅ UT HUR MÅNGA TIMMAR EN SPECIFIK ANSTÄLLD JOBBAT EN SPECIFIK VECKA
        public async Task<TimReport> SearchTimReport(int id, int choosenWeek)
        {
            var result = await _appContext.TimReports.Include(e => e.Employee).Where(t=> t.Week == choosenWeek).FirstOrDefaultAsync(e => e.EmployeeID == id);

            if (result != null)
            {
                var query = (from e in _appContext.Employees
                             join t in _appContext.TimReports
                             on e.EmployeeID equals t.EmployeeID
                             where t.Week == choosenWeek
                             select new
                             {
                                 empFName = e.FName,
                                 empLName = e.LName,
                                 week = t.Week,
                                 hours = t.wWorkingHours

                             }).ToList();
                return result;
            }
            return null;
        }
    }
}
