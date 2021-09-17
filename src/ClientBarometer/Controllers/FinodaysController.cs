using System;
using System.Threading;
using System.Threading.Tasks;
using Finodays.Contracts.Responses;
using Finodays.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientBarometer.Controllers
{
    [ApiController]
    [Route("finodays")]
    public class FinodaysController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<FinodaysController> _logger;
        
        public FinodaysController(IUserService userService, ILogger<FinodaysController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet("user")]
        public async Task<User> GetUser(Guid userId, CancellationToken cancellationToken)
            => await _userService.GetUser(userId, cancellationToken);
        
        
        [HttpGet("users")]
        public async Task<User[]> GetUsers(CancellationToken cancellationToken)
            => await _userService.GetUserList(cancellationToken);
    }
}
