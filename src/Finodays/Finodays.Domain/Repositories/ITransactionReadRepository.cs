using System;
using System.Threading;
using System.Threading.Tasks;
using Finodays.Domain.Models;

namespace Finodays.Domain.Repositories
{
    public interface ITransactionReadRepository
    {
        Task<Transaction[]> GetList(Guid userId, CancellationToken cancellationToken);
        Task<Transaction[]> GetList(int userIntId, CancellationToken cancellationToken);
        Task<Transaction> Get(Guid transactionId, CancellationToken cancellationToken);
    }
}