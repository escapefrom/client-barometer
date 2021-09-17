using ClientBarometer.Common.Implementations.Repositories;
using Finodays.Domain.Models;
using Finodays.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finodays.Implementations.Repositories
{
    class TransactionRegisterRepository : RegisterRepository<Transaction>, ITransactionRegisterRepository
    {
        public TransactionRegisterRepository(DbSet<Transaction> dbSet) : base(dbSet)
        {
        }
    }
}