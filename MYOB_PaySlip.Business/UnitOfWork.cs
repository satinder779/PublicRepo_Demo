
using System;
using MYOB_PaySlip_Models;
using MYOB_PaySlip_Models.Repositories;
using MYOB_PaySlip.Business.Repositories;

namespace MYOB_PaySlip.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        private IPaySlipRepository _paySlipRepository;

        public IPaySlipRepository PaySlipRepository
        {
            get { return _paySlipRepository ?? (_paySlipRepository = new PaySlipRepository()); }
        }

        public void Dispose()
        {
            _paySlipRepository = null;
        }
    }
}
