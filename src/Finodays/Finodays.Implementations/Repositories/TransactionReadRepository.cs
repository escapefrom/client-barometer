using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Finodays.DataAccess;
using Finodays.Domain.Constants;
using Finodays.Domain.Models;
using Finodays.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Finodays.Implementations.Repositories
{
    public class TransactionReadRepository : ITransactionReadRepository
    {
        private readonly IQueryable<Transaction> _transactions;

        public TransactionReadRepository(FinodaysDbContext dbContext)
        {
            _transactions = dbContext.Transactions.AsNoTracking();
        }
        
        public async Task<Transaction[]> GetList(Guid userId, CancellationToken cancellationToken)
            => await _transactions
            .Where(tr => tr.UserId == userId)
            .ToArrayAsync(cancellationToken);
        
        public async Task<Transaction[]> GetList(int userIntId, CancellationToken cancellationToken)
            => await _transactions
                .Where(tr => tr.UserIntId == userIntId)
                .ToArrayAsync(cancellationToken);

        public async Task<Transaction> Get(Guid userId, CancellationToken cancellationToken)
            => await _transactions
                .FirstOrDefaultAsync(tr => tr.UserId == userId, cancellationToken);
    }
}
