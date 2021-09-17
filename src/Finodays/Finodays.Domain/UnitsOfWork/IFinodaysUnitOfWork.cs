using ClientBarometer.Common.Abstractions.UnitOfWork;
using Finodays.Domain.Repositories;

namespace Finodays.Domain.UnitsOfWork
{
    public interface IFinodaysUnitOfWork : IUnitOfWork
    {
        IUserRegisterRepository Users { get; }
        ITransactionRegisterRepository Transactions { get; }
    }
}