using System;
using System.ComponentModel.DataAnnotations;

namespace Finodays.Domain.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public int IntId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }

    }
}