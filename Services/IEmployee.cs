using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Services
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();
        Task<Employee> GetEmployeeTimReport(int id);
        Task<Employee> Add(Employee newEntity);
        Task<Employee> Update(Employee entity);
        Task<Employee> Delete(int id);
        Task<Employee> GetSingle(int id);

    }
}
