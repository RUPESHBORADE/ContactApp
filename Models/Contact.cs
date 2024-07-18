using System.ComponentModel.DataAnnotations;

namespace ContactApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100)] // Adjust max length as needed
        public string Email { get; set; }

    }
}
