using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ClientBarometer.Contracts.Responses
{
    public class Chat
    {
        public Guid Id { get; set; }
        public string SourceId { get; set; }
        public string Source { get; set; }
        public string Username { get; set; }
    }
}