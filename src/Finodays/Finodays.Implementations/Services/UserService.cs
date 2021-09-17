using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Finodays.Domain.Constants;
using Finodays.Domain.Repositories;
using Finodays.Domain.Services;
using Finodays.Implementations.Exceptions;
using Finodays.Implementations.Mappers;
using Requests = Finodays.Contracts.Requests;
using Responses = Finodays.Contracts.Responses;

namespace Finodays.Implementations.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITransactionReadRepository _transactionReadRepository;
        private readonly IMapper _mapper = Create.FinodaysMapper.Please;

        public UserService(IUserReadRepository userReadRepository, ITransactionReadRepository transactionReadRepository)
        {
            _userReadRepository = userReadRepository;
            _transactionReadRepository = transactionReadRepository;
        }
        
        public async Task<Responses.User> GetUser(Guid userId, CancellationToken cancellationToken)
        {
            if (!await _userReadRepository.Contains(userId, cancellationToken))
            {
                throw new UserNotFoundException(userId.ToString());
            }
            var user = await _userReadRepository.Get(userId, cancellationToken);
            var userResult = _mapper.Map<Responses.User>(user);
            userResult.Transactions = _mapper.Map<Responses.Transaction[]>(await _transactionReadRepository.GetList(user.Id, cancellationToken));
            return userResult;
        }

        public async Task<Responses.User[]> GetUserList(CancellationToken cancellationToken)
        {
            var users = await _userReadRepository.GetUsers(UserConsts.DefaultSkip, UserConsts.DefaultTake, cancellationToken);
            var usersResult = new List<Responses.User>();
            foreach (var user in users)
            {
                var userResult = _mapper.Map<Responses.User>(user);
                userResult.Transactions =
                    _mapper.Map<Responses.Transaction[]>(
                        await _transactionReadRepository.GetList(user.Id, cancellationToken));
                usersResult.Add(userResult);
            }
            return usersResult.ToArray();
        }
    }
}