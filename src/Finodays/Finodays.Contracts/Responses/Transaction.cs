using System;
using System.ComponentModel.DataAnnotations;

namespace Finodays.Contracts.Responses
{
    public class Transaction
    {   
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid UserIntId { get; set; }
        public decimal Sum { get; set; }
        public string Currency { get; set; }
        public string PurposeOfPayment { get; set; }
        public string MccCode { get; set; }
        public string MccDecryption { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}