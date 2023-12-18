using SportsPro.Models.DataAccess.SeedData;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace SportsPro.Models
{
    public class Product
    {
        public Product() => Customers = new HashSet<Customer>();
        public int ProductID { get; set; }

        [Required]
        public string ProductCode { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(1, 10000)]
        [Column(TypeName = "decimal (8, 2)")]
        public decimal YearlyPrice { get; set; }

        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public string Slug()
        {
            return Name.Replace(' ', '-').ToLower();
        }

        public ICollection<Customer> Customers { get; set; }
    }
}
