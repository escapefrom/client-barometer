using ClientBarometer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClientBarometer.Domain.Repositories
{
    public interface IObjectionHandlingReadRepository
    {
        //Task<string[]> GetObjectionClasses(CancellationToken cancellationToken);
        //Task<Objection[]> GetObjections(string objectionClass, int skip, int take, CancellationToken cancellationToken);
        Task<Objection[]> GetAllObjections(int skip, int take, CancellationToken cancellationToken);
    }
}
