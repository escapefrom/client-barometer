using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Contracts.Requests;
using ClientBarometer.Domain.Models;

namespace ClientBarometer.Domain.Services
{
    public interface ISourceProcessor
    {
        Task ProcessToSource(IMessageRequest message, CancellationToken cancellationToken);
        Task ProcessFromSource(IMessageRequest message, CancellationToken cancellationToken);
    }
}