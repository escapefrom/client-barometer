using System.Threading;
using System.Threading.Tasks;
using Finodays.DataAccess;
using Finodays.Domain.Repositories;
using Finodays.Domain.UnitsOfWork;
using Finodays.Implementations.Repositories;

namespace Finodays.Implementations.UnitsOfWork
{
    public class FinodaysUnitOfWork : IFinodaysUnitOfWork
    {
        private readonly FinodaysDbContext _dbContext;
        public IUserRegisterRepository Users { get; }
        public ITransactionRegisterRepository Transactions { get; }
        
        public FinodaysUnitOfWork(FinodaysDbContext dbContext)
        {
            _dbContext = dbContext;
            Users = new UserRegisterRepository(dbContext.Users);
            Transactions = new TransactionRegisterRepository(dbContext.Transactions);
        }
        
        public async Task Complete(CancellationToken ct)
        {
            await _dbContext.SaveChangesAsync(ct);
        }
    }
}