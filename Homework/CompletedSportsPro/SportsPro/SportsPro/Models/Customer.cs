﻿using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string State { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string CountryID { get; set; }

        public Country Country { get; set; }

        public string Phone { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
    }
}
