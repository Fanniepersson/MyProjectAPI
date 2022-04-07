using Microsoft.EntityFrameworkCore;
using MyProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProjectAPI.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimReport> TimReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 1, FName = "Jasmine", LName = "Coleman", Email = "jasmine@company.se", ProjectID = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 2, FName = "Lucas", LName = "Brown", Email = "lucas@company.se", ProjectID = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 3, FName = "Liam", LName = "Mackay", Email = "liam@company.se", ProjectID = 1 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 4, FName = "Emily", LName = "Young", Email = "emily@company.se", ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 5, FName = "Dylan", LName = "Terry", Email = "dylan@company.se", ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 6, FName = "Carolyn", LName = "North", Email = "carolyn@company.se", ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 7, FName = "Sue", LName = "McKenzie", Email = "sue@company.se", ProjectID = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 8, FName = "Brian", LName = "Hamilton", Email = "brian@company.se", ProjectID = 3 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 9, FName = "Leah", LName = "Ellison", Email = "leah@company.se", ProjectID = 3 });
            modelBuilder.Entity<Employee>().HasData(new Employee { EmployeeID = 10, FName = "Adrian", LName = "Walsh", Email = "adrian@company.se", ProjectID = 3 });



            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 1, ProjectName = "Project 1" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 2, ProjectName = "Project 2" });
            modelBuilder.Entity<Project>().HasData(new Project { ProjectID = 3, ProjectName = "Project 3" });


            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 1, Week = 1, wWorkingHours = 20, EmployeeID = 1 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 2, Week = 1, wWorkingHours = 45, EmployeeID = 2 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 3, Week = 1, wWorkingHours = 50, EmployeeID = 3 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 4, Week = 1, wWorkingHours = 30, EmployeeID = 4 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 5, Week = 1, wWorkingHours = 40, EmployeeID = 5 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 6, Week = 1, wWorkingHours = 40, EmployeeID = 6 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 7, Week = 1, wWorkingHours = 40, EmployeeID = 7 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 8, Week = 1, wWorkingHours = 15, EmployeeID = 8 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 9, Week = 1, wWorkingHours = 40, EmployeeID = 9 });
            modelBuilder.Entity<TimReport>().HasData(new TimReport { ReportID = 10, Week = 1, wWorkingHours = 25, EmployeeID = 10 });






        }


    }
}
