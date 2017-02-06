using System;
using MYOB_PaySlip_Models.Repositories;

namespace MYOB_PaySlip_Models
{
    public interface IUnitOfWork : IDisposable
    {
        IPaySlipRepository PaySlipRepository { get; }
    }
}