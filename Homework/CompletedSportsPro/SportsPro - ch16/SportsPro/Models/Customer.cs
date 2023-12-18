using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Enter a first name.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a last name.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter an address.")]
        [StringLength(50)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a city.")]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter a state.")]
        [StringLength(50)]
        public string State { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the postal code.")]
        [StringLength(20)]
        public string PostalCode { get; set; } = string.Empty;

        public string CountryID { get; set; }

        public Country? Country { get; set; }

        [RegularExpression(@"^((\(\d{3}\) ?)|(\d{3}-))?\d[3]-\d{4}$", ErrorMessage = "Phone number must be in (111) 111-1111 format.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmail", "Validation", AdditionalFields = "CustomerID")]
        public string Email { get; set; } = string.Empty;

        public ICollection<Registration> Registrations { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
