using System.Threading;
using System.Threading.Tasks;
using Responses = ClientBarometer.Contracts.Responses;
using Requests = ClientBarometer.Contracts.Requests;

namespace ClientBarometer.Domain.Services
{
    public interface IAudioService
    {
        Task<Requests.CreateMessageRequest> GetTextMessage(Requests.CreateAudioMessageRequest request,
            CancellationToken cancellationToken);
    }
}