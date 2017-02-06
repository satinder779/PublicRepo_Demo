
using System.Web.Mvc;
using MYOB_PaySlip_Models.Models;
using MYOB_PaySlip_Models;

namespace MYOB_PaySlip.Web.Controllers
{
    public class PaySlipController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaySlipController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public ActionResult GeneratePaySlip()
        {
            return View(new EmployeeDetailsModel());
        }

        [HttpPost]
        public ActionResult GeneratePaySlip(EmployeeDetailsModel model)
        {
            if (ModelState.IsValid)
            {
                var paySlip = _unitOfWork.PaySlipRepository.GeneratePaySlip(model);
                return RedirectToAction("ViewPaySlip", paySlip);
            }
            return View(model);
        }

        public ActionResult ViewPaySlip(EmployeePaySlipModel paySlipModel)
        {
            return View(paySlipModel);
        }
    }
}