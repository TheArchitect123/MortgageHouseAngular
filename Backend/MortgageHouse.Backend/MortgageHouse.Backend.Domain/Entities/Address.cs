using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MortgageHouse.Backend.Domain.Entities
{
    public class Address
    {
        [Required]
        public string StreetNumber { get; set; }

        [Required]
        public string StreetName { get; set; }
        [Required]
        public StreetType StreetOption { get; set; }

        [Required]
        public string Suburb { get; set; }
        [Required]
        public int Postcode { get; set; }
    }
}
