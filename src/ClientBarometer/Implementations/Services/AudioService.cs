using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using ClientBarometer.Domain.Clients;
using ClientBarometer.Domain.Services;
using Responses = ClientBarometer.Contracts.Responses;
using Requests = ClientBarometer.Contracts.Requests;

namespace ClientBarometer.Implementations.Services
{
    public class AudioService : IAudioService
    {
        private readonly ISpeechToTextClient _speechToTextClient;

        public AudioService(ISpeechToTextClient speechToTextClient)
        {
            _speechToTextClient = speechToTextClient;
        }
        
        public async Task<Requests.CreateMessageRequest> GetTextMessage(Requests.CreateAudioMessageRequest request,
            CancellationToken cancellationToken)
        {
            var textResult = await _speechToTextClient.SafeGetValue(new Requests.GetSpeechToTextRequest
            {
                Data = Convert.ToBase64String(request.AudioData)
            }, cancellationToken);
            if (textResult.IsSuccess)
            {
                var text = textResult.Result.Result;
                return new Requests.CreateMessageRequest
                {
                    Source = request.Source,
                    ChatSourceId = request.ChatSourceId,
                    UserSourceId = request.UserSourceId,
                    Text = text
                };
            }
            else
            {
                return new Requests.CreateMessageRequest
                {
                    Text = string.Empty
                };
            }
        }
    }
}