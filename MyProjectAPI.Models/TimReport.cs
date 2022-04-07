using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProjectAPI.Models
{
    public class TimReport
    {
        [Key]
        public int ReportID { get; set; }
        [Required]
        public int Week { get; set; }
        [Required]
        public double wWorkingHours { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
