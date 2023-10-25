using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp11.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySalesApp11.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Enter the employee first name")]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter the employee last name")]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter employee date of birth")]
        [PastDate(ErrorMessage = "Employee DOB must be in the past")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "FirstName, LastName")]
        [Display(Name = "Birth Date")]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Enter employee hire date")]
        [PastDate(ErrorMessage = "Employee hire date must be in the past")]
        [GreaterThan("1/1/1995", ErrorMessage = "Hire date cannot be earlier than company founded")]
        [Display(Name = "Hire Date")]
        public DateTime? DateOfHire { get; set; }

        [GreaterThan(0, ErrorMessage = "Select the employee manager")]
        [Remote("CheckManager", "Validation", AdditionalFields = "FirstName, LastName, DOB")]
        [Display(Name = "Manager")]
        public int ManagerID { get; set; }

        public string FullName => $"{FirstName} {LastName}";


    }
}
