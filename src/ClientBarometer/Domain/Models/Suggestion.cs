using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBarometer.Domain.Models
{
    public class Suggestion
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ObjectionClass { get; set; }
        [Required]
        public string Processing { get; set; }
        [Required]
        public string Text { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
    }
}
