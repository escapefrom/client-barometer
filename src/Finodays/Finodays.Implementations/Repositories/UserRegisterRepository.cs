using ClientBarometer.Common.Implementations.Repositories;
using Finodays.Domain.Models;
using Finodays.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Finodays.Implementations.Repositories
{
    class UserRegisterRepository : RegisterRepository<User>, IUserRegisterRepository
    {
        public UserRegisterRepository(DbSet<User> dbSet) : base(dbSet)
        {
        }
    }
}