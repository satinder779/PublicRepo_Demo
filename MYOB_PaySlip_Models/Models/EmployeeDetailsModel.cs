using System;
using System.ComponentModel.DataAnnotations;

namespace MYOB_PaySlip_Models.Models
{
    public class EmployeeDetailsModel
    {
        private DateTime _startdate = DateTime.Now;
        private DateTime _enddate = DateTime.Now;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Annual Income")]
        [Range(1, double.MaxValue, ErrorMessage = "Annual Salary must be a positive number and greater than zero.")]
        public double AnnualIncome { get; set; }

        [Required]
        [Display(Name = "Super Rate (%)")]
        [Range(1, int.MaxValue, ErrorMessage = "Super Rate must be a positive number and greater than zero.")]
        public double SuperRate { get; set; }

        [Required]
        [Display(Name = "Payment Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime PaymentStartDate
        {
            get { return _startdate; }
            set { _startdate = value; }
        }

        [Required]
        [Display(Name = "Payment End Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime PaymentEndDate
        {
            get { return _enddate; }
            set { _enddate = value; }
        }
    }
}