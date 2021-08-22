using System;
using System.ComponentModel.DataAnnotations;

namespace ClientBarometer.Contracts.Responses
{
    public class Suggestions
    {
        public Suggestion[] Messages { get; set; }
    }

    public class Suggestion
    {
        public Guid Id { get; set; }

        public string Text { get; set; }
    }
}