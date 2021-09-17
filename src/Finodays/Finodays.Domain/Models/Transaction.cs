using System;
using System.ComponentModel.DataAnnotations;

namespace Finodays.Domain.Models
{
    public class Transaction
    {
        [Required]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int UserIntId { get; set; }
        public decimal Sum { get; set; }
        public string Currency { get; set; }
        public string PurposeOfPayment { get; set; }
        public string MccCode { get; set; }
        public string MccDecryption { get; set; }
        public DateTime CreatedAt { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }

    }
}