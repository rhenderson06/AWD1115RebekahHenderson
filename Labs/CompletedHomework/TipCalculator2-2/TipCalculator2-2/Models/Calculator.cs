using System.ComponentModel.DataAnnotations;

namespace TipCalculator2_2.Models
{
    public class Calculator
    {
        [Required(ErrorMessage = "Enter a value for cost of meal")]
        [Range(1, 1000, ErrorMessage = "Meal cost must be between 1 and 1000")]
        public double? MealCost { get; set; }

        public double CalculateTip(double percent)
        {
            if(MealCost.HasValue)
            {
                var tip = MealCost.Value * percent;
                return tip;
            }
            else { return 0; }
        }
    }
}
