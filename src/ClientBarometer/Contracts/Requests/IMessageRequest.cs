using System;

namespace ClientBarometer.Contracts.Requests
{
    public interface IMessageRequest
    {
        public string Source { get; set; }
        public string ChatSourceId { get; set; }
        public string UserSourceId { get; set; }
    }
}