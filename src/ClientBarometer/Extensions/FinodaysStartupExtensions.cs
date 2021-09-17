using ClientBarometer.Implementations.UnitsOfWork;
using Finodays.Domain.Repositories;
using Finodays.Domain.Services;
using Finodays.Domain.UnitsOfWork;
using Finodays.Implementations.Repositories;
using Finodays.Implementations.Services;
using Finodays.Implementations.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace ClientBarometer.Extensions
{
    public static class FinodaysStartupExtensions
    {
        public static IServiceCollection AddFinodays(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();

            services.AddScoped<IFinodaysUnitOfWork, FinodaysUnitOfWork>();

            return services;
        }
    }
}