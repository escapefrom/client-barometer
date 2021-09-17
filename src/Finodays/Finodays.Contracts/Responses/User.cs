using System;
using System.ComponentModel.DataAnnotations;

namespace Finodays.Contracts.Responses
{
    public class User
    {
        public Guid Id { get; set; }
        public int IntId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public Transaction[] Transactions { get; set; }
    }
}