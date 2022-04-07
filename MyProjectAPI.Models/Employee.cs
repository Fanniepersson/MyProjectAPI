using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyProjectAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string LName { get; set; }
        [Required]
        public string Email { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }

        public ICollection<TimReport> TimReport { get; set; }
    }
}
