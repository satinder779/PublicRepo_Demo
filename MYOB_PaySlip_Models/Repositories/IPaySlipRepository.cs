using MYOB_PaySlip_Models.Models;

namespace MYOB_PaySlip_Models.Repositories
{
    public interface IPaySlipRepository
    {
        EmployeePaySlipModel GeneratePaySlip(EmployeeDetailsModel employeeDetails);
    }
}