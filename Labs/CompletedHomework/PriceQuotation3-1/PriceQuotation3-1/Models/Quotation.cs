using System.ComponentModel.DataAnnotations;

namespace PriceQuotation3_1.Models
{
    public class Quotation
    {
        [Required(ErrorMessage = "Enter a sales price")]
        [Range(1, 1000000, ErrorMessage = "Sales amount must be between 1 and 1,000,000")]
        public double? Subtotal { get; set; }

        [Required(ErrorMessage = "Enter a discount amount")]
        [Range(0, 100, ErrorMessage = "Discount percent must be between 0 and 100")]
        public double? DiscountPercent { get; set; }

        public double CalculateDiscount()
        {
            if (Subtotal.HasValue && DiscountPercent.HasValue)
            {
                return Subtotal.Value * (DiscountPercent.Value / 100);
            }
            else { return 0.0; }
        }

        public double CalculateTotal()
        {
            if (Subtotal.HasValue)
            {
                double discount = CalculateDiscount();
                return Subtotal.Value - discount;
            }
            else { return 0.0; }
        }
    }
}
