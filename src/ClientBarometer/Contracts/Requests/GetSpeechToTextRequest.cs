using System.Buffers.Text;

namespace ClientBarometer.Contracts.Requests
{
    public class GetSpeechToTextRequest
    {
        public string Data { get; set; }
    }
}