using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MYOB_PaySlip.Web.Models
{
    public class Employee
    {
        [Required]
        [Display(Name = "Id")]
        public int EmpId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string EmpName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DOB { get; set; }
    }
}