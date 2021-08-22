using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Contracts.Requests;
using ClientBarometer.Contracts.Responses;
using ClientBarometer.Domain.Clients;
using ClientBarometer.Domain.Models;
using Flurl.Http;

namespace ClientBarometer.Implementations.Clients
{
    public class SpeechToTextClient : ISpeechToTextClient
    {
        private readonly IFlurlClient _client;
        
        public SpeechToTextClient(HttpClient httpClient)
        {
            _client = new FlurlClient(httpClient);
        }
        
        public async Task<GetSpeechToTextResult> GetValue(GetSpeechToTextRequest request, CancellationToken cancellationToken)
            => await _client
                .Request("speech_to_text")
                .PostJsonAsync(request, cancellationToken)
                .ReceiveJson<GetSpeechToTextResult>();

        public async Task<OperationResult<GetSpeechToTextResult>> SafeGetValue(GetSpeechToTextRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ans = await GetValue(request, cancellationToken);
                return new OperationResult<GetSpeechToTextResult>(ans);
            }
            catch (Exception e)
            {
                return new OperationResult<GetSpeechToTextResult>(e);
            }
        }
    }
}