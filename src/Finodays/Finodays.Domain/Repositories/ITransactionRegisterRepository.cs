using ClientBarometer.Common.Abstractions.Repositories;
using Finodays.Domain.Models;

namespace Finodays.Domain.Repositories
{
    public interface ITransactionRegisterRepository : IRegisterRepository<Transaction>
    {
    }
}