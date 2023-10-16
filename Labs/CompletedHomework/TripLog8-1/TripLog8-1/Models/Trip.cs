using System.ComponentModel.DataAnnotations;

namespace TripLog8_1.Models
{
    public class Trip
    {
        public int TripID { get; set; }

        [Required(ErrorMessage = "Provide a destination")]
        public string Destination { get; set; } = string.Empty;

        [Required(ErrorMessage = "Provide a start date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Provide an end date")]
        public DateTime? EndDate { get; set; }

        public string? Accommodation { get; set; } = null;
        public string? AccommodationPhone { get; set; } = null;
        public string? AccomodationEmail { get; set; } = null;

        public string? ThingToDo { get; set; } = null;
        public string? ThingToDo2 { get; set; } = null;
        public string? ThingToDo3 { get; set; } = null;
    }
}
