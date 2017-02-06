using System;
using MYOB_PaySlip_Models.Models;
using MYOB_PaySlip_Models.Repositories;
using MYOB_PaySlip_Models;

namespace MYOB_PaySlip.Business.Repositories
{
    internal class PaySlipRepository : IPaySlipRepository
    {
        internal PaySlipRepository()
        {
        }

        public EmployeePaySlipModel GeneratePaySlip(EmployeeDetailsModel employeeDetails)
        {
            var paySlip = new EmployeePaySlipModel();
            paySlip.Name = string.Format("{0} {1}", employeeDetails.FirstName, employeeDetails.LastName);
            paySlip.PaymentPeriod = GetPayPeriod(employeeDetails.PaymentStartDate, employeeDetails.PaymentEndDate);
            paySlip.GrossIncome = GetGrossIncome(employeeDetails.AnnualIncome);
            paySlip.IncomeTax = GetIncomeTax(employeeDetails.AnnualIncome);
            paySlip.NetIncome = paySlip.GrossIncome - paySlip.IncomeTax;
            paySlip.Super = Math.Round(employeeDetails.SuperRate / 100 * paySlip.GrossIncome);
            return paySlip;
        }

        private string GetPayPeriod(DateTime StartDate, DateTime EndDate)
        {
            return StartDate != null && EndDate != null ?
                string.Format("{0} - {1}", StartDate.ToString("dd MMMM"), EndDate.ToString("dd MMMM")) : string.Empty;
        }

        private double GetGrossIncome(double AnnualIncome)
        {
            return Math.Round(AnnualIncome / 12);
        }

        private double GetIncomeTax(double AnnualIncome)
        {
            if(CheckSalaryRange(AnnualIncome, Setting.Instance.SlabZeroLowerVal, Setting.Instance.SlabZeroUpperVal))
            {
                return CalculateIncomeTax(Setting.Instance.SlabZeroBaseTax, AnnualIncome, 
                    Setting.Instance.SlabZeroExemptIncome, Setting.Instance.SlabZeroTax);
            }
            if (CheckSalaryRange(AnnualIncome, Setting.Instance.SlabOneLowerVal, Setting.Instance.SlabOneUpperVal))
            {
                return CalculateIncomeTax(Setting.Instance.SlabOneBaseTax, AnnualIncome, 
                    Setting.Instance.SlabOneExemptIncome, Setting.Instance.SlabOneTax);
            }
            if (CheckSalaryRange(AnnualIncome, Setting.Instance.SlabTwoLowerVal, Setting.Instance.SlabTwoUpperVal))
            {
                return CalculateIncomeTax(Setting.Instance.SlabTwoBaseTax, AnnualIncome, 
                    Setting.Instance.SlabTwoExemptIncome, Setting.Instance.SlabTwoTax);
            }
            if (CheckSalaryRange(AnnualIncome, Setting.Instance.SlabThreeLowerVal, Setting.Instance.SlabThreeUpperVal))
            {
                return CalculateIncomeTax(Setting.Instance.SlabThreeBaseTax, AnnualIncome, 
                    Setting.Instance.SlabThreeExemptIncome, Setting.Instance.SlabThreeTax);
            }
            if (CheckSalaryRange(AnnualIncome, Setting.Instance.SlabFourLowerVal, Setting.Instance.SlabFourUpperVal))
            {
                return CalculateIncomeTax(Setting.Instance.SlabFourBaseTax, AnnualIncome,
                    Setting.Instance.SlabFourExemptIncome, Setting.Instance.SlabFourTax);
            }

            return 0;
        }

        private bool CheckSalaryRange(double AnnualIncome, double LowerLimit, double UpperLimit)
        {
            return ((AnnualIncome >= LowerLimit) && (AnnualIncome <= UpperLimit));
        }

        private double CalculateIncomeTax(double Basetax, double AnnualIncome, double ExemptIncome, double Tax)
        {
            return Math.Round((Basetax + (AnnualIncome - ExemptIncome) * Tax) / 12);
        }
    }
}
