using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Contracts.Requests;
using ClientBarometer.Contracts.Responses;
using ClientBarometer.Domain.Models;

namespace ClientBarometer.Domain.Clients
{
    public interface ISpeechToTextClient
    {
        Task<GetSpeechToTextResult> GetValue(GetSpeechToTextRequest request, CancellationToken cancellationToken);
        Task<OperationResult<GetSpeechToTextResult>> SafeGetValue(GetSpeechToTextRequest request, CancellationToken cancellationToken);
    }
}