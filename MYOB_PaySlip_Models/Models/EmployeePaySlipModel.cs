using System.ComponentModel.DataAnnotations;

namespace MYOB_PaySlip_Models.Models
{
    public class EmployeePaySlipModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Payment Period")]
        public string PaymentPeriod { get; set; }

        [Display(Name = "Gross Income")]
        public double GrossIncome { get; set; }

        [Display(Name = "Net Income")]
        public double NetIncome { get; set; }

        [Display(Name = "Income Tax")]
        public double IncomeTax { get; set; }

        [Display(Name = "Super")]
        public double Super { get; set; }
    }
}