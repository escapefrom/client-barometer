using Finodays.DataAccess.Maps;
using Finodays.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Finodays.DataAccess
{
    public class FinodaysDbContext : DbContext
    {
        public FinodaysDbContext(DbContextOptions<FinodaysDbContext> options)
            : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Build<User>();
            builder.Build<Transaction>();
        }
    }
}