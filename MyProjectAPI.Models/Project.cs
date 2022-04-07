using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyProjectAPI.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required]
        public string ProjectName { get; set; }

        public ICollection<Employee> Employee { get; set; }

    }
}
