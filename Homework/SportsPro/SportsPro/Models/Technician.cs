using System;
using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
		public int TechID { get; set; }	   

		[Required]
		public string TechName { get; set; }

		[Required]
		public string TechEmail { get; set; }

		[Required]
		public string TechPhone { get; set; }
	}
}
