using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MortgageHouse.Backend.Domain.Entities
{
    public class Contact : IEquatable<Contact>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string DateOfBirth { get; set; }

        public bool Equals([AllowNull] Contact other)
        {
            return true;
        }
    }
}
