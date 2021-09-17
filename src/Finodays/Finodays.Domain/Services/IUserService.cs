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
    public interface IUserService
    {
        Task<Responses.User> GetUser(Guid userId, CancellationToken cancellationToken);
        Task<Responses.User[]> GetUserList(CancellationToken cancellationToken);
    }
}