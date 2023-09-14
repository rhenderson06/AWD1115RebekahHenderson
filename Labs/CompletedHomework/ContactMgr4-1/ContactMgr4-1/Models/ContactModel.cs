using System.ComponentModel.DataAnnotations;

namespace ContactMgr4_1.Models
{
    public class ContactModel
    {
        //primary key
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Enter contact's first name.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter contact's last name.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter contact's phone number.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter contact's email address.")]
        public string Email { get; set; } = string.Empty;

        public string? Organization { get; set; }

        public DateTime DateAdded { get; set; }

        //Foreign key
        [Range(1, 100, ErrorMessage = "Enter a contact category.")]
        public int CategoryId { get; set; }

        public CategoryModel? Category { get; set; }

        //Read-only property
        public string Slug => $"{FirstName?.Replace(' ', '-').ToLower()} - {LastName?.Replace(" ", "-").ToLower()}";


    }
}
