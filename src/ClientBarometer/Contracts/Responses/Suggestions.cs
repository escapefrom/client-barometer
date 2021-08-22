using System;
using System.ComponentModel.DataAnnotations;

namespace ClientBarometer.Contracts.Responses
{
    public class Suggestions
    {
        public class Suggestion
        {
            public Guid Id;
            public string Text;
        }
        public Suggestion[] Messages { get; set; }
    }
}