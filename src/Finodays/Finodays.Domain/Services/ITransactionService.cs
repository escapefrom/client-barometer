using System;
using System.Threading;
using System.Threading.Tasks;
using Finodays.Contracts.Requests;
using Finodays.Domain.Constants;
using Finodays.Domain.Models;
using Requests = Finodays.Contracts.Requests;
using Responses = Finodays.Contracts.Responses;

namespace Finodays.Domain.Services
{
    public interface ITransactionService
    {
        Task<Responses.Transaction> GetTransactions(Guid userId, CancellationToken cancellationToken);
    }
}