using System;
using MYOB_PaySlip.Business;
using MYOB_PaySlip_Models;
using MYOB_PaySlip_Models.Models;
using NUnit.Framework;

namespace MYOB_PaySlip.Web.Tests
{
    /// <summary>
    /// Summary description for PaySlipTest
    /// </summary>
    [TestFixture]
    public class PaySlipTest
    {
        private IUnitOfWork _iUnitOfWork;

        [Test]
        public void TestPaySlipName()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual("Ryan Chen", paySlip.Name);
        }

        [Test]
        public void TestPaymentPeriod()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual("01 March - 31 March", paySlip.PaymentPeriod);
        }

        [Test]
        public void TestGrossIncome()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual(10000, paySlip.GrossIncome);
        }

        [Test]
        public void TestNetIncome()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual(7304, paySlip.NetIncome);
        }

        [Test]
        public void TestIncomeTax()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual(2696, paySlip.IncomeTax);
        }

        [Test]
        public void TestSuper()
        {
            _iUnitOfWork = new UnitOfWork();
            var details = InitEmployeeDetails();
            var paySlip = _iUnitOfWork.PaySlipRepository.GeneratePaySlip(details);
            Assert.AreEqual(1000, paySlip.Super);
        }

        private EmployeeDetailsModel InitEmployeeDetails()
        {
            return new EmployeeDetailsModel
            {
                FirstName = "Ryan",
                LastName = "Chen",
                AnnualIncome = 120000,
                SuperRate = 10,
                PaymentStartDate = new DateTime(2017, 3, 01),
                PaymentEndDate = new DateTime(2017, 3, 31)
            };
        }
    }
}