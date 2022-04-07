using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Services
{
    public interface ITimReport
    {
        Task<TimReport> Add(TimReport NewEntity);
        Task<TimReport> Update(TimReport entity);
        Task<TimReport> Delete(int id);
        Task<TimReport> GetSingle(int id);
        IEnumerable<TimReport> GetAll();
        Task<TimReport> SearchTimReport(int id, int choosenWeek);

    }
}
