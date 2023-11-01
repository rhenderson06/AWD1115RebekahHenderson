using Microsoft.AspNetCore.Mvc;
using QuarterlySalesApp11.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySalesApp11.Models
{
    public class Sale
    {
        public int SaleID { get; set; }

        [Required(ErrorMessage = "Enter the sales quarter")]
        [Range(1, 4, ErrorMessage = "Sales quarter must be between 1 and 4")]
        public int? Quarter { get; set; }

        [Required(ErrorMessage = "Enter the sales year")]
        [GreaterThan(2000, ErrorMessage = "Sales year must be >= 2000")]
        public int? Year { get; set; }
        
        [Required(ErrorMessage = "Enter the sales amount")]
        [GreaterThan(0, ErrorMessage = "Sales amount must be > 0")]
        public int? Amount { get; set; }

        [GreaterThan(0, ErrorMessage = "Select an employee")]
        [Remote("CheckSales", "Validation", AdditionalFields = "Quarter, Year")]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        public Employee? Employee { get; set; }

    }
}
