using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBarometer.Domain.Models
{
    public class Objection
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string ObjectionClass { get; set; }
        [Required]
        public string Example { get; set; }
        public HashSet<string> SplittedExample { get => Example.Split(" ").ToHashSet(); }
        [Timestamp]
        public byte[] RowVersion { get; private set; }
    }
}
